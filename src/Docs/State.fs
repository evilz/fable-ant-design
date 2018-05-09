module App.State

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Import.Browser
open Global
open Types

let pageParser: Parser<Page->Page,Page> =
  oneOf [
    map Home (s "home")
    map Button (s "general" </> s "button" )
    map Icon (s "general" </> s "icon")
    map Grid (s "layout" </> s "grid")
    map Layout (s "layout" </> s "layout")
    map Affix (s "navigation" </> s "affix")
    map Breadcrumb (s "navigation" </> s "breadcrumb")
    map Dropdown (s "navigation" </> s "dropdown")
    map Menu (s "navigation" </> s "menu")
  ]

let urlUpdate (result: Option<Page>) model =
  match result with
  | None ->
    console.error("Error parsing url")
    model,Navigation.modifyUrl (getMenuInfo model.currentPage).hash
  | Some page ->
      { model with currentPage = page }, []

let init result =

  let (model, cmd) =
    urlUpdate result
      { currentPage = Home
        home = Home.State.init() |> fst
        menuCollapsed = false
        button = General.Button.State.init() |> fst
        icons = General.Icons.State.init() |> fst
        grid = Layout.Grid.State.init() |> fst
        layout = Layout.Layout.State.init() |> fst
        affix = Navigation.Affix.State.init() |> fst
        breadcrumb = Navigation.Breadcrumb.State.init() |> fst
        dropdown = Navigation.Dropdown.State.init() |> fst
        menu = Navigation.Menu.State.init() |> fst
      }
  model, cmd

let update msg model =
  match msg with
  | HomeMsg msg ->
      let (home, homeCmd) = Home.State.update msg model.home
      { model with home = home }, Cmd.map HomeMsg homeCmd
  | SiderMsg collapsed ->
      { model with menuCollapsed = collapsed }, Cmd.Empty
  | ButtonMsg msg -> 
      let (button, buttonCmd) = General.Button.State.update msg model.button
      { model with button = button }, Cmd.map ButtonMsg buttonCmd
  | IconsMsg msg -> 
      let (icon, iconCmd) = General.Icons.State.update msg model.icons
      { model with icons = icon }, Cmd.map IconsMsg iconCmd
  | GridMsg msg -> 
      let (grid, gridCmd) = Layout.Grid.State.update msg model.grid
      { model with grid = grid }, Cmd.map GridMsg gridCmd
  | LayoutMsg msg -> 
      let (layout, layoutCmd) = Layout.Layout.State.update msg model.layout
      { model with layout = layout }, Cmd.map LayoutMsg layoutCmd
  | AffixMsg msg -> 
      let (affix, affixCmd) = Navigation.Affix.State.update msg model.affix
      { model with affix = affix }, Cmd.map AffixMsg affixCmd
  | BreadcrumbMsg msg -> 
      let (breadcrumb, breadcrumbCmd) = Navigation.Breadcrumb.State.update msg model.breadcrumb
      { model with breadcrumb = breadcrumb }, Cmd.map BreadcrumbMsg breadcrumbCmd
  | DropdownMsg msg -> 
      let (dropdown, dropdownCmd) = Navigation.Dropdown.State.update msg model.dropdown
      { model with dropdown = dropdown }, Cmd.map DropdownMsg dropdownCmd
  | MenuMsg msg -> 
      let (menu, menuCmd) = Navigation.Menu.State.update msg model.menu
      { model with menu = menu }, Cmd.map MenuMsg menuCmd


