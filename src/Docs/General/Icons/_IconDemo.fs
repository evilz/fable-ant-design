module General.Icons.IconDemo
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD

let view () = 
    div [Style [FontSize 48]] [
      Icon.icon [ Icon.Type "api" ] []
      Icon.icon [ Icon.Type "api" ; Icon.Title "Api"] []
      Icon.icon [ Icon.Type "api" ; Icon.Title "Api Spin !"; Icon.Spin true] []
      Icon.icon [ Icon.Type "api" ; Style [Color "#1890ff"]] []
    ]