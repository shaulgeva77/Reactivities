import { Container, CssBaseline} from "@mui/material"
import { useEffect , useState } from "react"
import axios from "axios";
import NavBar from "./NavBar";
import ActivityDashboard from "../../Features/activities/dashboard/ActivitiyDashboard";
function App() {
const [activities, setActivities] = useState<Activity[]>([]);
const [selectedActivity, setSelectedActivity] = useState<Activity | undefined>(undefined);
const [editMode, setEditMode] = useState(false);
useEffect(()=>{
  axios.get<Activity[]>('https://localhost:5001/api/activities')
    .then(response=> setActivities(response.data))
    return () => {}
},[])
const handleSelectActivity = (id: string) => {
    setSelectedActivity(activities.find(x => x.id === id));
 }
 const handleCancelSelectActivity = () => {
    setSelectedActivity(undefined);
  }
const handleOpenForm = (id?: string) => {
    if (id) handleSelectActivity(id);
    else handleCancelSelectActivity();
    setEditMode(true);
  }
const handleFormClose = () => {
  setEditMode(false);
}
const handleSubmitForm = (activity:Activity) => {
  if (activity.id){
    setActivities(activities.map(x=>x.id ===activity.id?activity:x))  
  }
  else{
    
    setActivities([...activities,{...activity,id:activities.length.toString() }])
  }
  setEditMode(false);
}
const handleDelete = (id:string)=>{
  setActivities(activities.filter(x=>x.id!==id))
}
 return (
    <>
      <CssBaseline/>
      <NavBar openForm={handleOpenForm}/>
      <Container maxWidth='xl' sx={{mt:3}}>
      <ActivityDashboard 
          activities={activities}
          selectActivity={handleSelectActivity}
          cancelSelectActivity={handleCancelSelectActivity}
          selectedActivity={selectedActivity}
          openForm={handleOpenForm}
          closeForm={handleFormClose}
          editMode = {editMode}
          submitForm = {handleSubmitForm}
          deleteActivity = {handleDelete}
          />
      </Container>
    </>
 )
}

export default App
