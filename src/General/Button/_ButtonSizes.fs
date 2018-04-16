module General.Button.ButtonSizes
open Fable.Helpers.React
open Fable.AntD

let view () = 
    div [] [
      Button.button [Button.ButtonProps.Size Button.Small ]   [str "Small"]
      Button.button [Button.ButtonProps.Size Button.Default ] [str "Default"]
      Button.button [Button.ButtonProps.Size Button.Large ]   [str "Large"]
    ]