import Image from 'next/image';
import React from 'react'
import Coundowntimer from './Coundowntimer';

type props = {
    auction: {
        id: number;
        make: string;
        imageUrl:string;
        model: string;
        year: number;
        auctionEnd: string;

    }
}
export default function AuctionCard({auction}: props ) {
  return (
    <a href="#">
      <div className='relative w-full bg-gray-200 aspect-video rounded-lg overflow-hidden'>
            <Image 
            src={auction.imageUrl} 
            alt={'image'}
            fill
            priority
            sizes='(max-width: 768px) 100vw, (max-width: 1200px) 50vw, 25vw'
            className='object-cover'
             />
        </div>
        <div className='flex justify-between items-center mt-4'>
            <h3 className='text-gray-700 '>{auction.make} {auction.model}</h3>
            <p className='text-sm font-semibold '>{auction.year}</p>
        </div>
        <Coundowntimer auctionEnd={auction.auctionEnd} />
    </a>
  )
}
