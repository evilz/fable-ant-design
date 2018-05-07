module App.Types

open Global

type Msg =
  | CounterMsg of Counter.Types.Msg
  | HomeMsg of Home.Types.Msg
  | ButtonMsg of General.Button.Types.Msg
  | IconsMsg of General.Icons.Types.Msg
  | GridMsg of Layout.Grid.Types.Msg
  | LayoutMsg of Layout.Layout.Types.Msg
  | AffixMsg of Navigation.Affix.Types.Msg
  | BreadcrumbMsg of Navigation.Breadcrumb.Types.Msg
  | DropdownMsg of Navigation.Dropdown.Types.Msg
  | MenuMsg of bool

type Model = {
    currentPage: Page
    counter: Counter.Types.Model
    home: Home.Types.Model
    menuCollapsed: bool
    button: General.Button.Types.Model
    icons: General.Icons.Types.Model
    grid: Layout.Grid.Types.Model
    layout: Layout.Layout.Types.Model
    affix: Navigation.Affix.Types.Model
    breadcrumb: Navigation.Breadcrumb.Types.Model
    dropdown: Navigation.Dropdown.Types.Model
  }
