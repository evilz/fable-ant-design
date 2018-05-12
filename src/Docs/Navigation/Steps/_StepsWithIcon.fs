module Navigation.Steps.StepsWithIcon
open Fable.Helpers.React
open Fable.AntD

let view () = 
  Steps.steps [] [
    Steps.step [Steps.Status Steps.Finish; Steps.Title (str "Login"); Steps.Icon (Icon.icon [Icon.Type "user"] [])] []
    Steps.step [Steps.Status Steps.Finish; Steps.Title (str "Verification"); Steps.Icon (Icon.icon [Icon.Type "solution"] [])] []
    Steps.step [Steps.Status Steps.Process; Steps.Title (str "Pay"); Steps.Icon (Icon.icon [Icon.Type "loading"] [])] []
    Steps.step [Steps.Status Steps.Wait; Steps.Title (str "Done"); Steps.Icon (Icon.icon [Icon.Type "smile-o"] [])] []
  ]