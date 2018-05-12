module Navigation.Steps.StepsMiniVersion
open Fable.Helpers.React
open Fable.AntD

let view () = 
  Steps.steps [Steps.Size Steps.Small; Steps.Current 1] [
    Steps.step [Steps.Title (str "Finished")] []
    Steps.step [Steps.Title (str "In Progress")] []
    Steps.step [Steps.Title (str "Waiting")] []
  ]