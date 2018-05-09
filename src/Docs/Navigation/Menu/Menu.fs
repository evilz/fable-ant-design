namespace Navigation.Menu

open Fable.Core
open Fable.Core.JsInterop
open Elmish
open Fable.AntD
open DemoCard.Types

module Types =

    [<StringEnum>]
    type MenuDemos = TopNavigation | Inline | CollapsedInline | OpenCurrentSubmenuOnly | VerticalMenu | MenuThemes


    type Model = {
      tabs: Map<MenuDemos,DemoCard.Types.Tab>
      collapsed:bool
      openKeys: string[]
      theme: Menu.MenuTheme
    }

    type Msg =
      | ChangeTabMsg of MenuDemos * DemoCard.Types.Tab
      | ToggleCollapsedMsg of bool
      | OpenChangeMsg of string[]
      | ChangeThemeMsg of bool 

open Types

module State =

    let init () : Model * Cmd<Msg> =
      let tabs = [TopNavigation; Inline; CollapsedInline; OpenCurrentSubmenuOnly; VerticalMenu; MenuThemes ]
                  |> List.map (fun x->x,DemoCard.Types.Demo) 
                  |>  Map.ofList 
                  
      {tabs = tabs; collapsed = false; openKeys = [|"sub1"|]; theme = Menu.Dark }, Cmd.Empty

    let update msg (model:Model) : Model * Cmd<Msg> =
       match msg with
       | ChangeTabMsg (demo,tab) -> {model with tabs = model.tabs.Add(demo, tab)}, []
       | ToggleCollapsedMsg (collapsed) -> {model with collapsed = collapsed }, []
       | OpenChangeMsg keys -> { model with openKeys = keys }, []
       | ChangeThemeMsg isDark -> { model with theme = (if isDark then Menu.Dark else Menu.Light) }, []

module View =

    open Fable.Helpers.React
    open Fable.Helpers.React.Props

           
    let root (model:Model) (dispatch:Msg->unit) =

      let demos =
        [|
          TopNavigation, { title = "Top navigation" ; 
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
          OpenCurrentSubmenuOnly, { title = "Open current submenu only" ; 
            demo = Navigation.Menu.OpenCurrentSubmenuOnly.view model.openKeys (OpenChangeMsg >> dispatch); 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_OpenCurrentSubmenuOnly.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          VerticalMenu, { title = "Vertical menu" ; 
            demo = Navigation.Menu.VerticalMenu.view;
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_VerticalMenu.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          MenuThemes, { title = "Menu themes" ; 
            demo = Navigation.Menu.MenuThemes.view model.theme  (ChangeThemeMsg >> dispatch);
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_MenuThemes.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
        |] |> Map.ofArray

      let renderDemo demo  = 
        DemoCard.View.root {demos.[demo] with activeTab = model.tabs.[demo] }  (fun msg -> ChangeTabMsg (demo, msg) |> dispatch  ) 
     

      div [ ClassName "menu-demo"  ] [
        h1 [] [str "Menu"] 
        Grid.row [ Grid.Gutter 16; ] [
          Grid.col [ ] ([ TopNavigation ] |> List.map renderDemo)
        ]
        Grid.row [ Grid.Gutter 16; ] [
          Grid.col [ Grid.Span 12; Grid.Xl (12 |> U2.Case1);Grid.Lg (12 |> U2.Case1); Grid.Md (12 |> U2.Case1); Grid.Sm (24 |> U2.Case1);Grid.Xs (24 |> U2.Case1)  ]
            ([ Inline; OpenCurrentSubmenuOnly ] |> List.map renderDemo)
          Grid.col [ Grid.Span 12; Grid.Xl (12 |> U2.Case1);Grid.Lg (12 |> U2.Case1); Grid.Md (12 |> U2.Case1); Grid.Sm (24 |> U2.Case1);Grid.Xs (24 |> U2.Case1)  ]
            ([ CollapsedInline;  VerticalMenu; MenuThemes ] |> List.map renderDemo)
        ]
      ]
