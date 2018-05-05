namespace Layout.Layout

open Fable.Core
open Fable.Core.JsInterop
open Elmish
open DemoCard.Types

module Types =

    

    [<StringEnum>]
    type LayoutsDemos = Basic
    type Model = Map<LayoutsDemos,DemoCard.Types.Tab> 

    type Msg =
      | ChangeTabMsg of LayoutsDemos * DemoCard.Types.Tab

open Types

module State =

    let init () : Model * Cmd<Msg> =
      [Basic]
      |> List.map (fun x->x,DemoCard.Types.Demo) 
      |>  Map.ofList , Cmd.Empty

    let update msg (model:Model) : Model * Cmd<Msg> =
       match msg with
       | ChangeTabMsg (demo,tab) -> model.Add(demo, tab), []


module View =

    open Fable.Helpers.React
    open Fable.Helpers.React.Props
    
    importAll "./Layout.less" 

    let demos =
        [|
          Basic, { title = "Basic Layout" ; 
            demo = Layout.Layout.BasicLayout.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_BasicLayout.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
        |] |> Map.ofArray

    let renderDemo dispatch (demos:Map<LayoutsDemos,DemoCardModel>) (model:Model) demo  = 
      DemoCard.View.root {demos.[demo] with activeTab = model.[demo] }  (fun msg -> ChangeTabMsg (demo, msg) |> dispatch  ) 
          

    let root (model:Model) (dispatch:Msg->unit) =

      let renderDemo = renderDemo dispatch demos model
      div [ ClassName "layout-demo"  ] [
              yield h1 [] [str "Layout"] 
              yield! [ Basic]
                      |> List.map renderDemo
            ]
