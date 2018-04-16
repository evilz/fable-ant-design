module App.Types

open Global
open Fable.AntD.Menu

type Msg =
  | CounterMsg of Counter.Types.Msg
  | HomeMsg of Home.Types.Msg
  | ButtonMsg of General.Button.Types.Msg
  | MenuMsg of bool

type Model = {
    currentPage: Page
    counter: Counter.Types.Model
    home: Home.Types.Model
    menuCollapsed: bool
    button: General.Button.Types.Model
  }
