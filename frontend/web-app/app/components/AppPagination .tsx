'use client'
import { Pagination } from 'flowbite-react'

type props = {currentPage: number 
             PageCount: number
             pageChange : (pageNumber: number) => void
            }
export default function AppPagination ({currentPage , PageCount ,pageChange}: props) {

  return (
    <Pagination
        currentPage={currentPage}
        totalPages={PageCount}
        onPageChange={e => pageChange(e)}
        showIcons={true}
        className={'text-blue-500 mb-5'}
        layout='pagination'
    />
  )
}
