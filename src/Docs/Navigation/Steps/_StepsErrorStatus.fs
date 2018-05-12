module Navigation.Steps.StepsErrorStatus
open Fable.Helpers.React
open Fable.AntD

let view () = 
  Steps.steps [Steps.Status Steps.Error; Steps.Current 1] [
    Steps.step [Steps.Title (str "Finished"); Steps.Description (str "This is a description.")] []
    Steps.step [Steps.Title (str "In Progress"); Steps.Description (str "This is a description.")] []
    Steps.step [Steps.Title (str "Waiting"); Steps.Description (str "This is a description.")] []
  ]