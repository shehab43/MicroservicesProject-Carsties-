import React from 'react'
import Coundowntimer from './Coundowntimer';
import CarImage from './CarImage';
import { Auction } from '../types/Index';


type props = {
  auction: Auction
}
export default function AuctionCard({auction}: props ) {
  return (
    <a href="#" className='group'>
      <div className='relative w-full bg-gray-200 aspect-video rounded-lg overflow-hidden'>
           <CarImage imageUrl={auction.imageUrl} />
        <div className='absolute bottom-2 left-2 '>
        <Coundowntimer auctionEnd={auction.auctionEnd} />

        </div>
        </div>

        <div className='flex justify-between items-center mt-4'>
            <h3 className='text-gray-700 '>{auction.make} {auction.model}</h3>
            <p className='text-sm font-semibold '>{auction.year}</p>
        </div>
    </a>
  )
}
