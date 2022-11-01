import React from "react";
import { Link } from "react-router-dom";
import {FolderService} from "../FolderService";
import Image from "../img/open-folder.png";
import Folder from "./Folder";
class Directory extends React.Component {
  constructor(props) {
    super(props);
    this.children= []
    this.path = ""
    this.parent = 0;
    this.state = {
        children:[],
        path:"",
        parent:0
    };
  }
  componentDidMount() {
    console.log(this.props.match.url.slice(5))
    let path2 = this.props.match.url.slice(5);
    let a =new FolderService();
    a.GetChildrenByPath(path2).then((x) => {
        this.children= x.list
        console.log(path2)
        if(path2[path2.length-1]=='/')
           path2=path2.slice(0,-1)
        console.log(path2)
        this.path= ":/"+path2
        a.GetByPath(path2).then(y=>{
          a.GetById(y.obj.parentId).then(z=>{
            this.parent = z.obj
            this.setState({ children:this.children,path:this.path ,parent:this.parent});
          })

        })

    });
    
  }
  render() {
    return (
      <>
        <div
          className="d-flex justify-content-center"
          style={{  margin: "100px"  }}
        >
            <Link  to={this.state.parent!=null?"/dir/"+this.state.path.slice(2).split(this.state.parent.name)[0]+this.state.parent.name :"/"} className="btn btn-light" style={{ width: "70px" ,alignSelf:"start",marginRight:"15px"}}>Prev</Link>
          <div style={{backgroundColor:"rgba(0,0,0,0.1)"}} className="d-flex flex-column">
            
            <div style={{ fontSize: "40px" ,color:"cyan"}}>{this.state.path}</div>
            
          <div   className="d-flex justify-content-center"> 
          {
           this.state.children.length>0?
          
          this.state.children.map(x=><Folder id={x.id} name={x.name} path={this.state.path.slice(2)+"/"+x.name}></Folder>)
        :
        <div style={{ fontSize: "30px" ,margin:"30px"}}> Folder is empty</div>
        }
          </div></div>
        </div>
      </>
    );
  }
}
export default Directory;
