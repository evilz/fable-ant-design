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
    map (General Button) (s "general" </> s "button" )
    map (General Icon) (s "general" </> s "icon")
  ]

let urlUpdate (result: Option<Page>) model =
  match result with
  | None ->
    console.error("Error parsing url")
    model,Navigation.modifyUrl (getMenuInfo model.currentPage).hash
  | Some page ->
      { model with currentPage = page }, []

let init result =
  let (counter, counterCmd) = Counter.State.init()
  let (home, homeCmd) = Home.State.init()
  let (model, cmd) =
    urlUpdate result
      { currentPage = Home
        counter = counter
        home = home
        menuCollapsed = false
        button = General.Button.State.init() |> fst
        icons = General.Icons.State.init() |> fst
      }
  model, Cmd.batch [ cmd
                     Cmd.map CounterMsg counterCmd
                     Cmd.map HomeMsg homeCmd ]

let update msg model =
  match msg with
  | CounterMsg msg ->
      let (counter, counterCmd) = Counter.State.update msg model.counter
      { model with counter = counter }, Cmd.map CounterMsg counterCmd
  | HomeMsg msg ->
      let (home, homeCmd) = Home.State.update msg model.home
      { model with home = home }, Cmd.map HomeMsg homeCmd
  | MenuMsg collapsed ->
      { model with menuCollapsed = collapsed }, Cmd.Empty
  | ButtonMsg msg -> 
      let (button, buttonCmd) = General.Button.State.update msg model.button
      { model with button = button }, Cmd.map ButtonMsg buttonCmd
  | IconsMsg msg -> 
      let (icon, iconCmd) = General.Icons.State.update msg model.icons
      { model with icons = icon }, Cmd.map IconsMsg iconCmd

