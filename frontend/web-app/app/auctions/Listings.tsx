'use client'

import React, { useEffect, useState } from 'react'
import AuctionCard from './AuctionCard';
import { Auction, PageResult } from '../types/Index';
import AppPagination from '../components/AppPagination ';
import { getData } from '../actions/auctionActions';
import Filter from './Filter';
import { useParamsStore } from '../hooks/useParamsStore';
import { useShallow } from 'zustand/shallow';
import queryString from 'query-string';


export default  function Listings() {
  // const [auctions, setAuctions] = useState<Auction[]>([]);
  // const [pageCount, setPageCount] = useState<number>(0);
  // const [pageNumber, setPageNumber] = useState<number>(1);
  // const [pageSize, setPageSize] = useState<number>(4);


  const [data , setData] = useState<PageResult<Auction>>();
  const params = useParamsStore(useShallow( data => ({
    pageNumber: data.pageNumber,
    pageSize: data.pageSize,
    searchTerm : data.searchTerm
  })));

  const setParams = useParamsStore(state => state.setParams);
  const url = queryString.stringifyUrl({url: '',query: params});

  function setPageNumber(pageNumber:number){
    setParams({pageNumber})
  }
  useEffect(() => {
    getData(url).then((data) => {
      setData(data);

    })
  // useEffect(() => {
  //   getData(pageNumber,pageSize).then((data) => {
  //     setAuctions(data.results);
  //     setPageCount(data.pageCount);

  //   })
  },[url])
  if(!data) return <h3>Loading...</h3>
  return (
    <>
    <Filter pageSize={pageSize} setPageSize={setPageSize}></Filter>
    <div className='grid grid-cols-4 gap-6 '>
      {
      auctions.map((auction: Auction) => (
         <AuctionCard auction={auction} key={auction.id} />
      ))}
    </div>
    <div className='flex justify-center mt-4'>
      <AppPagination
        currentPage={pageNumber}
         PageCount={pageCount}
         pageChange = {setPageNumber}  />
    </div>
    </>

  )
}
