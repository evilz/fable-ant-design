namespace Navigation.Dropdown

open Fable.Core
open Fable.Core.JsInterop
open Elmish
open Fable.AntD
open DemoCard.Types

module Types =

    [<StringEnum>]
    type DropdownDemos = Basic | Placement | OtherElements | Trigger | ClickEvent | Button | Cascading | Hidding | ContextMenu

    type Model = {
      tabs:Map<DropdownDemos,DemoCard.Types.Tab>
      visible:bool
    } 

    type Msg =
      | ChangeTabMsg of DropdownDemos * DemoCard.Types.Tab
      | VisibleMsg of bool

open Types

module State =

    let init () : Model * Cmd<Msg> =
      let tabs = [Basic; Placement; OtherElements; Trigger; ClickEvent; Button; Cascading; Hidding; ContextMenu]
                  |> List.map (fun x->x,DemoCard.Types.Demo) 
                  |>  Map.ofList
      
      {tabs = tabs; visible = false } , Cmd.Empty

    let update msg (model:Model) : Model * Cmd<Msg> =
       match msg with
       | ChangeTabMsg (demo,tab) -> {model with tabs = model.tabs.Add(demo, tab) }, []
       | VisibleMsg visible -> {model with visible = visible }, []

module View =

    open Fable.Helpers.React
    open Fable.Helpers.React.Props

    let root (model:Model) (dispatch:Msg->unit) =

      let demos =
        [|
          Basic, { title = "Basic" ; 
            demo = Navigation.Dropdown.BasicDropdown.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_BasicDropdown.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          Placement, { title = "Placement" ; 
            demo = Navigation.Dropdown.DropdownPlacement.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_DropdownPlacement.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          OtherElements, { title = "Other elements" ; 
            demo = Navigation.Dropdown.DropdownOtherElements.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_DropdownOtherElements.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          Trigger, { title = "Trigger mode" ; 
            demo = Navigation.Dropdown.DropdownTrigger.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_DropdownTrigger.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          ClickEvent, { title = "Click event" ; 
            demo = Navigation.Dropdown.DropdownClickEvent.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_DropdownClickEvent.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          Button , { title = "Button with dropdown menu" ; 
            demo = Navigation.Dropdown.DropdownButton.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_DropdownButton.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          Cascading, { title = "Cascading menu" ; 
            demo = Navigation.Dropdown.DropdownCascading.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_DropdownCascading.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          DropdownDemos.ContextMenu , { title = "Context Menu" ; 
            demo = Navigation.Dropdown.DropdownContextMenu.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_DropdownContextMenu.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          DropdownDemos.Hidding , { title = "The way of hiding menu" ; 
            demo = (fun () -> Navigation.Dropdown.DropdownHidding.view model.visible (fun visible -> VisibleMsg (visible) |> dispatch)) ; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_DropdownHidding.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
        |] |> Map.ofArray

      let renderDemo demo= 
        DemoCard.View.root {demos.[demo] with activeTab = model.tabs.[demo] }  (fun msg -> ChangeTabMsg (demo, msg) |> dispatch  ) 
          

      div [ ClassName "dropdown-demo"  ] [
        h1 [] [str "Dropdown"] 
        Grid.row [ Grid.Gutter 16; ] [
          Grid.col [ Grid.Span 12; Grid.Xl (12 |> U2.Case1);Grid.Lg (12 |> U2.Case1); Grid.Md (12 |> U2.Case1); Grid.Sm (24 |> U2.Case1);Grid.Xs (24 |> U2.Case1)  ]
            ([ Basic; OtherElements; ClickEvent;Cascading; DropdownDemos.ContextMenu ] |> List.map renderDemo)
          Grid.col [ Grid.Span 12; Grid.Xl (12 |> U2.Case1);Grid.Lg (12 |> U2.Case1); Grid.Md (12 |> U2.Case1); Grid.Sm (24 |> U2.Case1);Grid.Xs (24 |> U2.Case1)  ]
            ([ Placement; Trigger; Button; Hidding ] |> List.map renderDemo)
        ]
      ]
