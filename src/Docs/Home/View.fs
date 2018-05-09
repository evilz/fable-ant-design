module Home.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open DemoCard.Types
open Fable.AntD

let root model dispatch =
  div [] [
    div [ Style [TextAlign "center"] ] [
      h1 [Style [FontSize "5em"] ] [str "Welcome to Fable Ant Design !"] 
      p [Style [FontSize 32; Color "black"]  ] [
        a [Href "http://fable.io/"] [
          img [Style [Height 64]; Src "http://fable.io/img/shared/fable_logo.png"] 
        ]
        str " binding for the awesome "
        a [Href "https://ant.design/"] [
          img [Style [Height 64]; Src "https://gw.alipayobjects.com/zos/rmsportal/KDpgvguMpGfqaHPjicRK.svg"] 
          img [Style [Height 32]; Src "https://gw.alipayobjects.com/zos/rmsportal/DkKNubTaaVsKURhcVGkh.svg"]
        ]
        
     ]
    ]
    Card.card [ ClassName "demo-card"; Card.Title  (str "Getting started") ] [
        div [] [
                h2 [] [str "Install nuget package using paket"]
                p [] [ pre [] [ code [ ClassName "hljs shell" ] [str "paket add Fable.Ant.Design --project <your project>"] ]]
                p [ ] [ str "Then dotnet restore on your *.fsproj file."]

                h2 [] [str "Install Ant design npm"]
                p [] [ pre [] [ code [ ClassName "hljs shell" ] [str "yarn add antd"] ]]

                h2 [] [str "Import the style in your F# app"]
                p [] [ pre [] [ code [ ClassName "hljs fsharp" ] [str "importAll \"../../node_modules/antd/dist/antd.less\""] ]]
          ]
      ]
  ]
