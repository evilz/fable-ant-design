module Navigation.Steps.StepsSwitchStep
open Fable.Helpers.React.Props
open Fable.AntD
open Fable.Helpers.React

let message = Message.message
let steps = [
  "First", "First-content"
  "Second", "Second-content"
  "Last", "Last-content"
]

let view current next prev () = 

  let currentTitle, currentContent = steps.[current]
  
  div [] [
    Steps.steps [Steps.Current current] 
      (steps |> List.map (fun (title,_) -> Steps.step [Key title; Steps.Title (str title)] []))
      
    div [ClassName "steps-content" ] [str currentContent]
    div [ClassName "steps-action" ] [
      if current < steps.Length - 1 then 
        yield Button.button [Button.Type Button.Primary; OnClick (fun _ -> next() )] [str "Next"]
      if current = steps.Length - 1 then 
        yield Button.button [Button.Type Button.Primary; OnClick (fun _ -> message.success("Processing complete!") )] [str "Done"]
      if current > 0 then
        yield Button.button [Button.Type Button.Primary; OnClick (fun _ -> prev() )] [str "Previous"]
    ]
  ]