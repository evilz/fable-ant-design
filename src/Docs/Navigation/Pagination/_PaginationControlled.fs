module Navigation.Pagination.PaginationControlled
open Fable.AntD

let view current onChange () = 
  Pagination.pagination [
    Pagination.Current current
    Pagination.OnChange (fun current pageSize -> onChange current )
    Pagination.Total 50 ] []
  