import React, {Component} from 'react';
import Menu from '../menu/menu';
const ButtonEx=()=>{
  const Datta=()=>{
    alert("Hi I am Datta");
  }
  const Vardhan=()=>{
    alert("Hi i am Vardhan");
  }
  const Deva=()=>{
    alert("Hi i am Deva");
  }
 return (
  <div>
    <Menu/>
    <input type="button" value="Datta" onClick={Datta}></input>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <input type="button" value="Vardhan" onClick={Vardhan}></input>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <input type="button" value="Deva" onClick={Deva}></input>
  </div>
 )
}
export default ButtonEx;