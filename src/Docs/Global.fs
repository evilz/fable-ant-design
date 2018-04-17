module Global

type GeneralComponents =
  | Button
  | Icon

type LayoutComponents = 
  | Grid
  | Layout

type NavigationComponents = 
  | Affix
  | Breadcrumb
  | Dropdown
  | Menu
  | Pagination
  | Steps

type DataEntryComponents = 
  | AutoComplete
  | Cascader
  | Checkbox
  | DatePicker
  | Pagination
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

type DataDisplayComponents = 
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

type FeedbackComponents = 
  | Alert
  | Modal
  | Message
  | Notification
  | Progress
  | Popconfirm
  | Spin

type OtherComponents = 
  | Anchor
  | BackTop
  | Divider
  | LocaleProvider

type Page =
  | Home
  | General of GeneralComponents
  | Layout of LayoutComponents
  | Navigation of NavigationComponents
  | DataEntry of DataEntryComponents
  | DataDisplay of DataDisplayComponents
  | Feedback of FeedbackComponents
  | Other of OtherComponents

type MenuInfo = { title:string; hash:string; icon:string}

let getMenuInfo page = 
  let (t,h,i) =
    match page with
    | Home -> "Home", "#home", "home"
    | General g -> 
      match g with
      | Button -> "Button", "#general/button", "scan"
      | Icon -> "Icon", "#general/icon", "picture"
    | _ -> "Home", "#home", "home"

  { title=t; hash=h; icon=i}