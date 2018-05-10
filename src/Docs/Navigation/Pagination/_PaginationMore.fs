module Navigation.Pagination.PaginationMore
open Fable.AntD

let view () = 
  Pagination.pagination [Pagination.DefaultCurrent 6; Pagination.Total 500] []