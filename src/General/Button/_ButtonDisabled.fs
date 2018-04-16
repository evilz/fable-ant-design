module General.Button.ButtonDisabled
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD

let view () = 
    div [] [
      Button.button [Button.Type Button.Primary] [ str "Primary" ]
      Button.button [Button.Type Button.Primary; Disabled true] [ str "Primary(disabled)" ]
      br []
      Button.button [] [ str "Default" ]
      Button.button [Disabled true] [ str "Default(disabled)" ]
      br []
      Button.button [Button.Type Button.Ghost] [ str "Ghost" ]
      Button.button [Button.Type Button.Ghost; Disabled true] [ str "Ghost(disabled)" ]
      br []
      Button.button [Button.Type Button.Dashed] [ str "Dashed" ]
      Button.button [Button.Type Button.Dashed; Disabled true] [ str "Dashed(disabled)" ]
      br []
    ]