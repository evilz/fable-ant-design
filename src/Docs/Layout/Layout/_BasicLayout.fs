module Layout.Layout.BasicLayout
open Fable.Helpers.React
open Fable.AntD

let view () = 
    div [] [
      Layout.layout [] [
        Layout.header [] [str "Header"]
        Layout.content [] [str "Content"]
        Layout.footer [] [str "Footer"]
      ]

      Layout.layout [] [
        Layout.header [] [str "Header"]
        Layout.layout [] [
          Layout.sider [] [str "Sider"]
          Layout.content [] [str "Content"]
        ]
        Layout.footer [] [str "Footer"]
      ]

      Layout.layout [] [
        Layout.header [] [str "Header"]
        Layout.layout [] [
          Layout.content [] [str "Content"]
          Layout.sider [] [str "Sider"]
        ]
        Layout.footer [] [str "Footer"]
      ]

      Layout.layout [] [
        Layout.sider [] [str "Sider"]
        Layout.layout [] [
          Layout.header [] [str "Header"]
          Layout.content [] [str "Content"]
          Layout.footer [] [str "Footer"]
        ]
      ]
    ]
    