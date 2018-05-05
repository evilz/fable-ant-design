namespace Navigation.Breadcrumb

open Fable.Core
open Fable.Core.JsInterop
open Elmish
open Fable.AntD
open DemoCard.Types

module Types =

    [<StringEnum>]
    type BreadcrumbDemos = Basic | WithIcon | Separator
    type Model = Map<BreadcrumbDemos,DemoCard.Types.Tab> 

    type Msg =
      | ChangeTabMsg of BreadcrumbDemos * DemoCard.Types.Tab

open Types

module State =

    let init () : Model * Cmd<Msg> =
      [Basic; WithIcon; Separator]
      |> List.map (fun x->x,DemoCard.Types.Demo) 
      |>  Map.ofList , Cmd.Empty

    let update msg (model:Model) : Model * Cmd<Msg> =
       match msg with
       | ChangeTabMsg (demo,tab) -> model.Add(demo, tab), []


module View =

    open Fable.Helpers.React
    open Fable.Helpers.React.Props


    let demos =
        [|
          Basic, { title = "Basic" ; 
            demo = Navigation.Breadcrumb.BasicBreadcrumb.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_BasicBreadcrumb.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          WithIcon, { title = "With an Icon" ; 
            demo = Navigation.Breadcrumb.BreadcrumbWithIcon.view;  
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_BreadcrumbWithIcon.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          Separator, { title = "Configuring the Separator" ; 
            demo = Navigation.Breadcrumb.BreadcrumbSeparator.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_BreadcrumbSeparator.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
        |] |> Map.ofArray

    let renderDemo dispatch (demos:Map<BreadcrumbDemos,DemoCardModel>) (model:Model) demo  = 
      DemoCard.View.root {demos.[demo] with activeTab = model.[demo] }  (fun msg -> ChangeTabMsg (demo, msg) |> dispatch  ) 
          

    let root (model:Model) (dispatch:Msg->unit) =

      let renderDemo = renderDemo dispatch demos model

      div [ ClassName "breadcrumb-demo"  ] [
        h1 [] [str "Breadcrumb"] 
        Grid.row [ Grid.Gutter 16; ] [
          Grid.col [ Grid.Span 12; Grid.Xl (12 |> U2.Case1);Grid.Lg (12 |> U2.Case1); Grid.Md (12 |> U2.Case1); Grid.Sm (24 |> U2.Case1);Grid.Xs (24 |> U2.Case1)  ]
            ([ Basic; Separator ] |> List.map renderDemo)
          Grid.col [ Grid.Span 12; Grid.Xl (12 |> U2.Case1);Grid.Lg (12 |> U2.Case1); Grid.Md (12 |> U2.Case1); Grid.Sm (24 |> U2.Case1);Grid.Xs (24 |> U2.Case1)  ]
            ([ WithIcon ] |> List.map renderDemo)
        ]
      ]
