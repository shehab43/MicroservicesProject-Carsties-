import React from 'react'
async function getData() {
    const res = await fetch('https://jsonplaceholder.typicode.com/posts');
          if(!res.ok) throw new Error('Something went wrong')
            return res.json()
          
}
export default async function Listings() {
    const data = await getData()    
  return (
    <div>
      {JSON.stringify(data,null,2)}
    </div>
  )
}
