module Global

type Page =
  | Home
  // general
  | Button
  | Icon
  // layout
  | Grid
  | Layout
  // navigation
  | Affix
  | Breadcrumb
  | Dropdown
  | Menu
  | Pagination
  | Steps
  // DataEntry
  | AutoComplete
  | Cascader
  | Checkbox
  | DatePicker
  | Form
  | Input
  | InputNumber
  | Mention
  | Rate
  | Radio
  | Select
  | Slider
  | Switch
  | TreeSelect
  | TimePicker
  | Transfer
  | Upload
  // DataDisplay
  | Avatar
  | Badge
  | Calendar
  | Card
  | Carousel
  | Collapse
  | List
  | Popover
  | Tooltip
  | Table
  | Tabs
  | Tag
  | Timeline
  | Tree
    // Feedback
  | Alert
  | Modal
  | Message
  | Notification
  | Progress
  | Popconfirm
  | Spin
  // Other
  | Anchor
  | BackTop
  | Divider
  | LocaleProvider

type MenuInfo = { title:string; hash:string; icon:string}

let getMenuInfo page = 
  let (t,h,i) =
    match page with
    | Home -> "Home", "#home", "home"
    // general
    | Button -> "Button", "#general/button", "scan"
    | Icon -> "Icon", "#general/icon", "picture"
    // layout
    | Grid -> "Grid", "#layout/grid", "appstore-o"
    | Layout -> "Layout", "#layout/layout", "layout"
    // navigation
    | Affix -> "Affix", "#navigation/affix", "up"
    | Breadcrumb -> "Breadcrumb", "#navigation/breadcrumb", "double-right"
    | Dropdown -> "Dropdown", "#navigation/dropdown", "down-square-o"
    | Menu -> "Menu", "#navigation/menu", "menu-unfold"
    | _ -> "Home", "#home", "home"

  { title=t; hash=h; icon=i}