import React, {Component,useState} from 'react';
import Menu from '../menu/menu';
const Four=()=>{

  const [name,setName]= useState('')
  const bheema=()=>
  {
    setName("Hi i am Bheema");
  }
  const srinu=()=>
  {
    setName("Hi my name is Srinu");
  }

const vijay=()=>{
  setName("Hi my name is Vijay");
}

 return (
  <div>
    <Menu/>
    <input type="button" value="Bheema" onClick={bheema}></input>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <input type="button" value="Srinu" onClick={srinu}></input>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <input type="button" value="Vijay" onClick={vijay}></input>
    <hr/>
    Name is : <b>{name}</b>
  </div>

 )
}
export default Four;