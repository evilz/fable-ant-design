namespace Navigation.Affix

open Fable.Core
open Fable.Core.JsInterop
open Elmish
open Fable.AntD
open DemoCard.Types

module Types =

    [<StringEnum>]
    type AffixDemos = Basic | Callback | Container
    type Model = Map<AffixDemos,DemoCard.Types.Tab> 

    type Msg =
      | ChangeTabMsg of AffixDemos * DemoCard.Types.Tab

open Types

module State =

    let init () : Model * Cmd<Msg> =
      [Basic; Callback; Container]
      |> List.map (fun x->x,DemoCard.Types.Demo) 
      |>  Map.ofList , Cmd.Empty

    let update msg (model:Model) : Model * Cmd<Msg> =
       match msg with
       | ChangeTabMsg (demo,tab) -> model.Add(demo, tab), []


module View =

    open Fable.Helpers.React
    open Fable.Helpers.React.Props
    
    importAll "./Affix.less" 

    let demos =
        [|
          Basic, { title = "Basic" ; 
            demo = Navigation.Affix.BasicAffix.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_BasicAffix.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          Callback, { title = "Callback" ; 
            demo = Navigation.Affix.AffixCallback.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_AffixCallback.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          Container, { title = "Container to scroll" ; 
            demo = Navigation.Affix.AffixContainer.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_AffixContainer.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
        |] |> Map.ofArray

    let renderDemo dispatch (demos:Map<AffixDemos,DemoCardModel>) (model:Model) demo  = 
      DemoCard.View.root {demos.[demo] with activeTab = model.[demo] }  (fun msg -> ChangeTabMsg (demo, msg) |> dispatch  ) 
          

    let root (model:Model) (dispatch:Msg->unit) =

      let renderDemo = renderDemo dispatch demos model

      div [ ClassName "affix-demo"  ] [
        h1 [] [str "Affix"] 
        Grid.row [ Grid.Gutter 16; ] [
          Grid.col [ Grid.Span 12; Grid.Xl (12 |> U2.Case1);Grid.Lg (12 |> U2.Case1); Grid.Md (12 |> U2.Case1); Grid.Sm (24 |> U2.Case1);Grid.Xs (24 |> U2.Case1)  ]
            ([ Basic ] |> List.map renderDemo)
          Grid.col [ Grid.Span 12; Grid.Xl (12 |> U2.Case1);Grid.Lg (12 |> U2.Case1); Grid.Md (12 |> U2.Case1); Grid.Sm (24 |> U2.Case1);Grid.Xs (24 |> U2.Case1)  ]
            ([ Callback; Container ] |> List.map renderDemo)
        ]
      ]
