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
    let id = this.props.match.params.id;
    let a =new FolderService();
    a.GetChildren(id).then((x) => {
        this.children= x.list
        this.path= x.path
        a.GetById(this.props.match.params.id).then(y=>{
            this.parent = y.obj.parentId
            console.log(y)
          this.setState({ children:this.children,path:this.path ,parent:this.parent});

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
            <Link  to={this.state.parent!=null?"/dir/"+this.state.parent:"/"} className="btn btn-light" style={{ width: "70px" ,alignSelf:"start",marginRight:"15px"}}>Prev</Link>
          <div style={{backgroundColor:"rgba(0,0,0,0.1)"}} className="d-flex flex-column">
            
            <div style={{ fontSize: "40px" ,color:"cyan"}}>{this.state.path}</div>
            
          <div   className="d-flex justify-content-center"> 
          {
           this.state.children.length>0?
          
          this.state.children.map(x=><Folder id={x.id} name={x.name}></Folder>)
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
