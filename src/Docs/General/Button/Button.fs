namespace General.Button

open Fable.Core
open Fable.Core.JsInterop
open Elmish

module Types =

    [<StringEnum>]
    type Demos = Type | Size | Icon | Disabled | Loading | MultipleButtons | ButtonGroup | GhostButton

    type Model = Map<Demos,DemoCard.Types.Tab> 

    type Msg =
      | ChangeTabMsg of Demos * DemoCard.Types.Tab

open Types

module State =
    
    let init () : Model * Cmd<Msg> =
      
      [ Type; Size; Icon; Disabled; Loading; MultipleButtons; ButtonGroup; GhostButton]  
      |> List.map (fun x->x,DemoCard.Types.Demo) 
      |>  Map.ofList , Cmd.Empty

    let update msg (model:Model) : Model * Cmd<Msg> =
       match msg with
       | ChangeTabMsg (demo,tab) -> model.Add(demo, tab), []


module View =

    open Fable.Helpers.React
    open Fable.AntD
    open DemoCard.Types

    let demos =
      [| Type, 
          { 
            title = "Type" ; 
            demo = General.Button.ButtonTypes.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_ButtonTypes.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
         Icon, { 
           title = "Icon"; 
           demo = General.Button.ButtonIcons.view; 
           source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_ButtonIcons.fs"; 
           activeTab = DemoCard.Types.Demo 
         }
         Size, { 
           title = "Size"; 
           demo = General.Button.ButtonSizes.view; 
           source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_ButtonSizes.fs"; 
           activeTab = DemoCard.Types.Demo 
         }
         Disabled,{ 
           title = "Disabled"; 
           demo = General.Button.ButtonDisabled.view; 
           source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_ButtonDisabled.fs"; 
           activeTab = DemoCard.Types.Demo 
         }
         Loading,{ 
           title = "Loading"; 
           demo = General.Button.ButtonLoading.view ; 
           source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_ButtonLoading.fs"; 
           activeTab = DemoCard.Types.Demo 
         }
         ButtonGroup, { 
           title = "Button Group"; 
           demo = General.Button.ButtonGroup.view ; 
           source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_ButtonGroup.fs"; 
           activeTab = DemoCard.Types.Demo 
         }
         MultipleButtons, { 
           title = "Multiple Buttons"; 
           demo = General.Button.ButtonMultiple.view ; 
           source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_ButtonMultiple.fs"; 
           activeTab = DemoCard.Types.Demo 
         }
         GhostButton, { 
           title = "Ghost Button"; 
           demo = General.Button.ButtonGhost.view ; 
           source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_ButtonGhost.fs"; 
           activeTab = DemoCard.Types.Demo 
         }
        |] |> Map.ofArray
    
    let renderDemo dispatch (demos:Map<Demos,DemoCardModel>) (model:Model) demo = 
      DemoCard.View.root {demos.[demo] with activeTab = model.[demo] }  (fun msg -> ChangeTabMsg (demo, msg) |> dispatch  ) 

    let root (model:Model) (dispatch:Msg->unit) =

      let renderDemo = renderDemo dispatch demos model
      div [ ] [
              h1 [] [str "Buttons"] 

              Grid.row [ Grid.Gutter 16; ] [
                  Grid.col [ Grid.Span 12; Grid.Xl (12 |> U2.Case1);Grid.Lg (12 |> U2.Case1); Grid.Md (12 |> U2.Case1); Grid.Sm (24 |> U2.Case1);Grid.Xs (24 |> U2.Case1)  ] [
                    renderDemo Type
                    renderDemo Size
                    renderDemo Loading
                    renderDemo ButtonGroup
                  ]
                  Grid.col [ Grid.Span 12; Grid.Xl (12 |> U2.Case1);Grid.Lg (12 |> U2.Case1); Grid.Md (12 |> U2.Case1); Grid.Sm (24 |> U2.Case1);Grid.Xs (24 |> U2.Case1)  ] [
                    renderDemo Icon
                    renderDemo Disabled
                    renderDemo MultipleButtons
                    renderDemo GhostButton
                  ]
              ]
            ]
