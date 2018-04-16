module General.Button.ButtonTypes
open Fable.Helpers.React
open Fable.AntD

let view () = 
    div [] [
      Button.button []                [str "Default"]
      Button.button [Button.primary]  [str "Primary"]
      Button.button [Button.danger]   [str "Danger"]
      Button.button [Button.dashed]   [str "Dashed"]
      Button.button [Button.ghost]    [str "Ghost"]
    ]