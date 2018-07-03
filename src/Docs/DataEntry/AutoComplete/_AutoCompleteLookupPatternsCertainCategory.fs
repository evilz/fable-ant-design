module DataEntry.AutoComplete.AutoCompleteLookupPatternsCertainCategory

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.Browser
open Fable.AntD

let onSelect (value:AutoComplete.SelectValue) _ =
    console.log("onSelect",value)

let view () = 
    AutoComplete.autoComplete [
        AutoComplete.DataSource [||]
        Style [ Width  200 ]
        AutoComplete.OnSelect onSelect
        Placeholder "input here"
    ] []



type ItemChildren = {title: string; count: int}
type Item = {title: string;children: ItemChildren[]}
let dataSource = 
    [|
        { title= "话题";
          children= 
            [|
                { title= "AntDesign"; count= 10000}
                { title= "AntDesign UI"; count= 10600 }
            |] }
        { title= "问题";
          children= 
            [|
              { title= "AntDesign UI 有多好"; count= 60100 }
              { title= "AntDesign 是啥"; count= 30010 }
            |] }
        { title= "文章"; 
          children= [|
                { title= "AntDesign 是一个设计语言"; count= 100000}
            |]
        }
    |]

let renderTitle title =
    span [] [
        str title
        a [Style [Float "right"]; Href "https://www.google.com/search?q=antd";Target "_blank"; Rel "noopener noreferrer" ] [str "更多"]
      ]

// let options = 
//     dataSource 
//     |> Array.map( fun group ->
//           AutoComplete.optGroup [Key group.title; AutoComplete.Label (renderTitle group.title) ] [
//               yield! group.children 
//               |> Array.map (fun opt -> 
//                                    AutoComplete.option [Key opt.title; Value opt.title ] [
//                                        str opt.title
//                                        span [ ClassName "certain-search-item-count" ] [str (sptrintf "%A 人 关注" opt.count)] ]
//                             )

//               yield AutoComplete.option [Disabled true; Key "all"; ClassName "show-all"] [
//                   a [Href "https://www.google.com/search?q=antd"; Target "_blank"; Rel "noopener noreferrer" ] [str  "查看所有结果"]
//               ] 
//           ]
//     )
