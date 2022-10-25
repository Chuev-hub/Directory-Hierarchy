
export  class FolderService{
    baseUrl = 'http://www.directory-hierarchy.somee.com/Folder/'
    async getFilm(id) {
        
    }
     async GetRoot()
    {
        let response = await fetch(this.baseUrl + 'GetRoot')
        let data = await response.json()
        return data
     
    }

     async  Get(){
        let response = await fetch(this.baseUrl+'Get' )
        let data = await response.json()
        return data
     }
     async  GetById( id){
        let response = await fetch(this.baseUrl+'GetById' + '?id='+id )
        let data = await response.json()
        return data
     }
    async GetChildren(id){
        let response = await fetch(this.baseUrl+'GetChildren'  + '?id='+id )
        let data = await response.json()
        return data
    }
     async SetHierarchy(json){
        let response = await fetch(this.baseUrl+'SetHierarchy' ,{
            method:"PUT",
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(json)
        })
      return (response)
     }
   
}
