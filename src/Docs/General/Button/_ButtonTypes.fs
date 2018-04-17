module General.Button.ButtonTypes
open Fable.Helpers.React
open Fable.AntD

let view () = 
    div [] [
      Button.button []                [str "Default"]
      Button.button [Button.Type Button.Primary]  [str "Primary"]
      Button.button [Button.Type Button.Danger]   [str "Danger"]
      Button.button [Button.Type Button.Dashed]   [str "Dashed"]
      Button.button [Button.Type Button.Ghost]    [str "Ghost"]
    ]