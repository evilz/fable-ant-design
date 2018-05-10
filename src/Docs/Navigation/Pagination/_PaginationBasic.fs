module Navigation.Pagination.PaginationBasic
open Fable.AntD

let view () = 
  Pagination.pagination [Pagination.DefaultCurrent 1; Pagination.Total 50] []