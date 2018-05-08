namespace Navigation.Menu

open Fable.Core
open Fable.Core.JsInterop
open Elmish
open Fable.AntD
open DemoCard.Types

module Types =

    [<StringEnum>]
    type MenuDemos = TopNavigation | Inline | CollapsedInline | OpenCurrentSubmenuOnly

    type Model = {
      tabs: Map<MenuDemos,DemoCard.Types.Tab>
      collapsed:bool
      openKeys: string[]
    }

    type Msg =
      | ChangeTabMsg of MenuDemos * DemoCard.Types.Tab
      | ToggleCollapsedMsg of bool
      | OpenChangeMsg of string

open Types

module State =

    let init () : Model * Cmd<Msg> =
      let tabs = [TopNavigation; Inline; CollapsedInline; OpenCurrentSubmenuOnly ]
                  |> List.map (fun x->x,DemoCard.Types.Demo) 
                  |>  Map.ofList 
                  
      {tabs = tabs; collapsed = false; openKeys = [|"sub1"|] }, Cmd.Empty

    let update msg (model:Model) : Model * Cmd<Msg> =
       match msg with
       | ChangeTabMsg (demo,tab) -> {model with tabs = model.tabs.Add(demo, tab)}, []
       | ToggleCollapsedMsg (collapsed) -> {model with collapsed = collapsed }, []
       | OpenChangeMsg key -> { model with openKeys = [|key|] }, []

module View =

    open Fable.Helpers.React
    open Fable.Helpers.React.Props

           
    let root (model:Model) (dispatch:Msg->unit) =

      let demos =
        [|
          TopNavigation, { title = "Top Navigation" ; 
            demo = Navigation.Menu.TopNavigation.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_TopNavigation.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          Inline, { title = "Inline menu" ; 
            demo = Navigation.Menu.InlineMenu.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_InlineMenu.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          CollapsedInline, { title = "Collapsed inline menu" ; 
            demo = Navigation.Menu.CollapsedInline.view model.collapsed (ToggleCollapsedMsg >> dispatch); 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_CollapsedInline.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          // OpenCurrentSubmenuOnly, { title = "Open current submenu only" ; 
          //   demo = Navigation.Menu.OpenCurrentSubmenuOnly.view; 
          //   source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_OpenCurrentSubmenuOnly.fs"; 
          //   activeTab = DemoCard.Types.Demo 
          // }
        |] |> Map.ofArray

      let renderDemo demo  = 
        DemoCard.View.root {demos.[demo] with activeTab = model.tabs.[demo] }  (fun msg -> ChangeTabMsg (demo, msg) |> dispatch  ) 
     

      div [ ClassName "menu-demo"  ] [
        yield h1 [] [str "Menu"] 
        yield! [ TopNavigation; Inline; CollapsedInline; ] |> List.map renderDemo
      ]
