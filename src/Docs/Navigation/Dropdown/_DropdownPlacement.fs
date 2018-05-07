module Navigation.Dropdown.DropdownPlacement
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD

let link href text =
  a [Target "_blank"; Rel "noopener noreferrer"; Href href ] [str text ] 

let menu = 
  Menu.menu [] [
    Menu.item [] [ link "http://www.alipay.com/" "1st menu item"]
    Menu.item [] [ link "http://www.taobao.com/" "2nd menu item"]
    Menu.item [] [ link "http://www.tmall.com/" "3rd menu item"]
  ]
let view () = 
    div [] [ 
      Dropdown.dropdown [Dropdown.Overlay menu; Dropdown.Placement Dropdown.BottomLeft] [
        Button.button [] [str "bottomLeft"]
      ]
      Dropdown.dropdown [Dropdown.Overlay menu; Dropdown.Placement Dropdown.BottomCenter] [
        Button.button [] [str "bottomCenter"]
      ]
      Dropdown.dropdown [Dropdown.Overlay menu; Dropdown.Placement Dropdown.BottomRight] [
        Button.button [] [str "bottomRight"]
      ]
      br []
      Dropdown.dropdown [Dropdown.Overlay menu; Dropdown.Placement Dropdown.TopLeft] [
        Button.button [] [str "topLeft"]
      ]
      Dropdown.dropdown [Dropdown.Overlay menu; Dropdown.Placement Dropdown.TopCenter] [
        Button.button [] [str "topCenter"]
      ]
      Dropdown.dropdown [Dropdown.Overlay menu; Dropdown.Placement Dropdown.TopRight] [
        Button.button [] [str "topRight"]
      ]
    ]