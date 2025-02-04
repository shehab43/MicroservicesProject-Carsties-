'use client';
import React from 'react'
import { AiOutlineCar } from 'react-icons/ai';

export default function Navbar() {
  return (
    <header className='flex justify-between sticky top-0 bg-white p-5 items-center text-gray-800 shadow-md'>
       <div className='flex items-center gap-2 text-3xl font-semibold text-red-500'>
       <AiOutlineCar size={34}/>
        <div>Carsites Auction</div>
       </div>
       <div>Search</div>
       <div>Login</div>
    </header>
  )
}
