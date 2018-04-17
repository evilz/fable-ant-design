module General.Button.ButtonLoading
open Fable.Helpers.React
open Fable.AntD

let view ()= 
    span [] [
        Button.button [Button.Loading true; Button.Type Button.Primary] [ str "Loading" ]
        Button.button [Button.Loading true; Button.Type Button.Primary; Button.Size Button.Small] [ str "Loading" ]
        br []
        Button.button [Button.Loading true; Button.Type Button.Primary] [ str "Click me!" ]
        Button.button [Button.Loading true; Button.Type Button.Primary; Button.Icon "poweroff"] [ str "Click me!" ]
        br []
        Button.button [Button.Loading true; Button.Shape Button.Circle ] [ ]
        Button.button [Button.Loading true; Button.Type Button.Primary; Button.Shape Button.Circle] [ ]
        br []
    ]
     