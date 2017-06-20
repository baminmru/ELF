
<?php
class  M_tpld_devtype extends CI_Model {
    function getRow($empId) {
    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');
	if (!empty($empId)){
	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'B2G(tpld_devtypeid) as tpld_devtypeid, B2G(tpld_devtypeid) as id,B2G(instanceid) as instanceid, TPLD_DEVTYPE_BRIEF_F(tpld_devtypeid , NULL) as  brief,driverlibname,name,B2G(DevClass) devclass, TPLD_DEVCLASS_BRIEF_F(devclass, NULL) as devclass_grid', 'PartName' => 'tpld_devtype', 'ID' =>  $empId 	));
	    if (!empty($res)) {
	        $result = $res[0];
	    }
	}
	return $result;
    }
    function setRow($data)  {
	    $data = (array)$data;
	if (!empty($data)) {
	    if (empty($data['tpld_devtypeid'])) {
	        $data['tpld_devtypeid'] = $this->jservice->get(array('Action' => 'NewGuid'));
	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpld_devtype', 'RowID' => $data['tpld_devtypeid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }else{
	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => 'tpld_devtype', 'RowID' => $data['tpld_devtypeid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }
	    return array('success' => TRUE, 'data' => $this->getRow($data['tpld_devtypeid'] ));
	} else {
	    return array('success' => FALSE, 'msg' => 'No data to store on server');
	}
    }
    function newRow($instanceid,$data)  {
	  $id = $this->jservice->get(array('Action' => 'NewGuid'));
	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpld_devtype', 'RowID' => $id, 'DocumentID' => $instanceid, 'Values'=>$data)) == 'OK') {
	    return array('success' => TRUE, 'data' => $id);
	} else {
	    return array('success' => FALSE, 'msg' => 'Error while create new id');
	}
    }
    function getRows($sort=array())
		{
	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpld_devtypeid) as tpld_devtypeid, B2G(tpld_devtypeid) as id,B2G(instanceid) as instanceid, TPLD_DEVTYPE_BRIEF_F(tpld_devtypeid , NULL) as  brief,driverlibname,name,B2G(DevClass) devclass, TPLD_DEVCLASS_BRIEF_F(devclass, NULL) as devclass_grid', 'ViewName' => 'tpld_devtype'));
	    if (count($res)) {
	        return $res;
	    } else {
	        return null;
	    }
		}
    function getRowsByInstance($id,$sort=array())
		{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpld_devtypeid) as tpld_devtypeid, B2G(tpld_devtypeid) as id,B2G(instanceid) as instanceid, TPLD_DEVTYPE_BRIEF_F(tpld_devtypeid , NULL) as  brief,driverlibname,name,B2G(DevClass) devclass, TPLD_DEVCLASS_BRIEF_F(devclass, NULL) as devclass_grid', 'ViewName' => 'tpld_devtype', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
		}
    function getRowsByParent($id,$sort=array())
	{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpld_devtypeid) as tpld_devtypeid, B2G(tpld_devtypeid) as id,B2G(instanceid) as instanceid, TPLD_DEVTYPE_BRIEF_F(tpld_devtypeid , NULL) as  brief,driverlibname,name,B2G(DevClass) devclass, TPLD_DEVCLASS_BRIEF_F(devclass, NULL) as devclass_grid', 'ViewName' => 'tpld_devtype', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
  }
    function deleteRow($id = null) {
	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => 'tpld_devtype', 'RowID' => $id)) == 'OK')
	    $result = array('success' => TRUE);
	else
	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');
	return $result;
    }
}
?>