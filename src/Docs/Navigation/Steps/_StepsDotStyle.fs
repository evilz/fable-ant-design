module Navigation.Steps.StepsDotStyle
open Fable.Core
open Fable.Helpers.React
open Fable.AntD

let view () = 
  Steps.steps [Steps.ProgressDot (U2.Case1 true); Steps.Current 1] [
    Steps.step [Steps.Title (str "Finished"); Steps.Description (str "This is a description.")] []
    Steps.step [Steps.Title (str "In Progress"); Steps.Description (str "This is a description.")] []
    Steps.step [Steps.Title (str "Waiting"); Steps.Description (str "This is a description.")] []
  ]