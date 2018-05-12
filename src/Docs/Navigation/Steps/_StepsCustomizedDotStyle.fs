module Navigation.Steps.StepsCustomizedDotStyle
open Fable.Core
open Fable.Helpers.React
open Fable.AntD

let customDot iconDot (info:Steps.StepProgressDotInfo) =
  let contentText = sprintf "step %i status: %s" info.index info.status 
  Popover.popover [Popover.Content (span [][str contentText]) ] [
    iconDot
  ]

let view () = 
  Steps.steps [Steps.Current 1; Steps.ProgressDot (U2.Case2 customDot) ] [
    Steps.step [Steps.Title (str "Finished"); Steps.Description (str "You can hover on the dot.")] []
    Steps.step [Steps.Title (str "In Progress"); Steps.Description (str "You can hover on the dot.")] []
    Steps.step [Steps.Title (str "Waiting"); Steps.Description (str "You can hover on the dot.")] []
    Steps.step [Steps.Title (str "Waiting"); Steps.Description (str "You can hover on the dot.")] []
  ]
