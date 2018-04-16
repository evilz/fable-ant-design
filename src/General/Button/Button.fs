module General.Button

open Fable.Core
open Fable.Core.JsInterop
open Elmish

module Types =

    type Model = Map<string,DemoCard.Types.Model> 

    type Msg =
      | ChangeTabMsg of string * DemoCard.Types.Tab

    [<StringEnum>]
    type Demos = Type | Size | Icon | Disabled | Loading | MultipleButtons | ButtonGroup | GhostButton


    
    let getTitle = function
      | Type -> "Type" 
      | Size -> "Size"
      | Icon -> "Icon"
      | Disabled -> "Disabled"
      | Loading -> "Loading"
      | MultipleButtons -> "Multiple Buttons"
      | ButtonGroup -> "Button Group"
      | GhostButton -> "Ghost Button"

 


open Types

module State =

    
    let init () : Model * Cmd<Msg> =
    
      let demos:DemoCard.Types.Model[] =
        [|
          { title = Type |> getTitle; 
            demo = General.Button.ButtonTypes.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_ButtonTypes.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          { title = Icon |> getTitle; 
            demo = General.Button.ButtonIcons.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_ButtonIcons.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          { title = Size |> getTitle; 
            demo = General.Button.ButtonSizes.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_ButtonSizes.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          { title = Disabled |> getTitle; 
            demo = General.Button.ButtonDisabled.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_ButtonDisabled.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          { title = Loading |> getTitle; 
            demo = General.Button.ButtonLoading.view ; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_ButtonLoading.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          { title = ButtonGroup |> getTitle; 
            demo = General.Button.ButtonGroup.view ; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_ButtonGroup.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          { title = MultipleButtons |> getTitle; 
            demo = General.Button.ButtonMultiple.view ; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_ButtonMultiple.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          { title = GhostButton |> getTitle; 
            demo = General.Button.ButtonGhost.view ; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_ButtonGhost.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          
        |]
    
      let model = demos
                    |> Seq.map (fun x -> x.title,x)
                    |> Map.ofSeq
        
      
      model , []

    let update msg (model:Model) : Model * Cmd<Msg> =
       match msg with
       | ChangeTabMsg (title,tab) ->
          model.Add(title, { model.[title] with DemoCard.Types.activeTab = tab}  ), []


module View =

    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Helpers.React
    open Fable.Helpers.React.Props
    open Types
    open Fable.AntD

    let renderDemo dispatch (demo:DemoCard.Types.Model)  = 
      DemoCard.View.root demo (fun msg -> ChangeTabMsg (demo.title, msg) |> dispatch  ) 
          

    let root (model:Model) (dispatch:Msg->unit) =

      let colOne = [ Type;Size; Loading; ButtonGroup ]
      let colTwo = [ Icon; Disabled; MultipleButtons; GhostButton ]

      let renderDemo = renderDemo dispatch
      div [ ] [
              h1 [] [str "Buttons"] 

              Grid.row [ Grid.Gutter 16; ] [
                  Grid.col [ Grid.Span 12; Grid.Xl (12 |> U2.Case1);Grid.Lg (12 |> U2.Case1); Grid.Md (12 |> U2.Case1); Grid.Sm (24 |> U2.Case1);Grid.Xs (24 |> U2.Case1)  ] [
                    for demo in colOne -> model.[(demo |> getTitle)] |> renderDemo
                  ]
                  Grid.col [ Grid.Span 12; Grid.Xl (12 |> U2.Case1);Grid.Lg (12 |> U2.Case1); Grid.Md (12 |> U2.Case1); Grid.Sm (24 |> U2.Case1);Grid.Xs (24 |> U2.Case1)  ] [
                    for demo in colTwo -> model.[(demo |> getTitle)] |> renderDemo
                  ]
              ]
             
              // div [] [
              //   Button.button [Disabled true] [str "Disabled"]
              // ]

              // div [] [
              //   Button.button [Button.ButtonProps.Loading true] [str "Loading"]
              //   Button.button [Button.primary;Button.ButtonProps.Loading true] [str "Loading"]
              //   Button.button [Button.ButtonProps.Loading true; Button.ButtonProps.Shape Button.Circle] []
              //   Button.button [Button.primary;Button.ButtonProps.Loading true; Button.ButtonProps.Shape Button.Circle] []
              // ]

              // div [] [
              //   Button.group [] [
              //     Button.button [] [str "Cancel"]
              //     Button.button [ ] [str "Ok"]
              //     Button.button [Button.Href "http://www.evilznet.com"; Button.Target "_blank" ] [str "Evilznet"]
              //   ] 
              // ]

            ]
