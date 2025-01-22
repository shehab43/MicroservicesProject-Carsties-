'use client'; 
import React from 'react'
import Countdown from 'react-countdown';
type Props = {
    auctionEnd: string;
  }
const renderer = ({days, hours, minutes, seconds, completed }:{days:number, hours:number, minutes:number, seconds:number, completed:boolean }) => {
    if (completed) {
      // Render a completed state
      return <span>Finished</span>;
    } else {
      // Render a countdown
      return <span>{days}:{hours}:{minutes}:{seconds}</span>;
    }
  };

  export default function Coundowntimer({auctionEnd}: Props) {
  return (
    <div>
      <Countdown date={auctionEnd} renderer={renderer} />
    </div>
  )
}

