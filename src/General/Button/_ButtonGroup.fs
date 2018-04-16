module General.Button.ButtonGroup
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD

let view ()= 
    div [] [
        h4 [] [ str "Basic"]
        Button.group [] [
            Button.button [] [ str "Cancel" ]
            Button.button [] [ str "OK" ] 
        ]
        Button.group [] [
            Button.button [Disabled true] [ str "L" ]
            Button.button [Disabled true] [ str "M" ] 
            Button.button [Disabled true] [ str "R" ] 
        ]
        Button.group [] [
            Button.button [] [ str "L" ]
            Button.button [] [ str "M" ] 
            Button.button [] [ str "R" ] 
        ]
        h4 [] [ str "BaWith Iconsic"]
        Button.group [] [
            Button.button [Button.Type Button.Primary] [ Icon.icon [Icon.Type "left"] []; str "Go back" ]
            Button.button [Button.Type Button.Primary] [ Icon.icon [Icon.Type "right"] []; str "Go forward" ]
        ]
        Button.group [] [
            Button.button [Button.Type Button.Primary; Button.Icon "cloud"] []
            Button.button [Button.Type Button.Primary; Button.Icon "cloud-download"] [ ]
        ]
    ]