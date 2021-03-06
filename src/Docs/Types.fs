module App.Types

open Global

type Msg =
  | HomeMsg of Home.Types.Msg
  | ButtonMsg of General.Button.Types.Msg
  | IconsMsg of General.Icons.Types.Msg
  | GridMsg of Layout.Grid.Types.Msg
  | LayoutMsg of Layout.Layout.Types.Msg
  | AffixMsg of Navigation.Affix.Types.Msg
  | BreadcrumbMsg of Navigation.Breadcrumb.Types.Msg
  | DropdownMsg of Navigation.Dropdown.Types.Msg
  | MenuMsg of Navigation.Menu.Types.Msg
  | PaginationMsg of Navigation.Pagination.Types.Msg
  | StepsMsg of Navigation.Steps.Types.Msg
  | AutoCompleteMsg of DataEntry.AutoComplete.Types.Msg
  | CascaderMsg of DataEntry.Cascader.Types.Msg
  | SiderMsg of bool

type Model = {
    currentPage: Page
    home: Home.Types.Model
    menuCollapsed: bool
    button: General.Button.Types.Model
    icons: General.Icons.Types.Model
    grid: Layout.Grid.Types.Model
    layout: Layout.Layout.Types.Model
    affix: Navigation.Affix.Types.Model
    breadcrumb: Navigation.Breadcrumb.Types.Model
    dropdown: Navigation.Dropdown.Types.Model
    menu: Navigation.Menu.Types.Model
    pagination: Navigation.Pagination.Types.Model
    steps: Navigation.Steps.Types.Model
    cascader: DataEntry.Cascader.Types.State
    autoComplete: DataEntry.AutoComplete.Types.Model
  }
