module App.Types

open Global

type Msg =
  | CounterMsg of Counter.Types.Msg
  | HomeMsg of Home.Types.Msg
  | ButtonMsg of General.Button.Types.Msg
  | IconsMsg of General.Icons.Types.Msg
  | GridMsg of Layout.Grid.Types.Msg
  | MenuMsg of bool

type Model = {
    currentPage: Page
    counter: Counter.Types.Model
    home: Home.Types.Model
    menuCollapsed: bool
    button: General.Button.Types.Model
    icons: General.Icons.Types.Model
    grid: Layout.Grid.Types.Model
  }
