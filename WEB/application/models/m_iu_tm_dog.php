﻿
<?php
class  M_iu_tm_dog extends CI_Model {
    function getRow($empId) {
    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');
	if (!empty($empId)){
	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'B2G(iu_tm_dogid) as iu_tm_dogid, B2G(iu_tm_dogid) as id,B2G(instanceid) as instanceid, iu_tm_dog_BRIEF_F(iu_tm_dogid , NULL) as  brief,  DATE_FORMAT(thedate,\'%Y-%m-%d\') as  thedate,thenumber,dogfile,dogfile_ext,info', 'PartName' => 'iu_tm_dog', 'ID' =>  $empId 	));
	    if (!empty($res)) {
	        $result = $res[0];
	    }
	}
	return $result;
    }
    function setRow($data)  {
	    $data = (array)$data;
//////////////////////////// support file data for: dogfile
    if ($_FILES['dogfile_fu']['size'] > 0 ) {
       $ext = pathinfo($_FILES['dogfile_fu']['name'], PATHINFO_EXTENSION);
       $filename = strtolower(trim($this->jservice->get(array('Action' => 'NewGuid')),'{}') . '.' . $ext);
       if (move_uploaded_file($_FILES['dogfile_fu']['tmp_name'], $this->jservice->temp_file_path().$filename)) {
          $file_data = file_get_contents($this->jservice->temp_file_path().$filename);
          $this->jservice->get(array('Action' => 'AddFile', 'FileName'=>$filename, 'Data'=>utf8_encode($file_data), 'FileID'=>'iu_files'));
          unlink($this->jservice->temp_file_path().$filename);
       }
	   if (!empty($data)) {
	        $data['dogfile']=$filename;
	        $data['dogfile_ext']=$ext;
       }
    }
//////////////////////////// end support file data for: dogfile
	if (!empty($data)) {
	    if (empty($data['iu_tm_dogid'])) {
	        $data['iu_tm_dogid'] = $this->jservice->get(array('Action' => 'NewGuid'));
	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'iu_tm_dog', 'RowID' => $data['iu_tm_dogid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }else{
	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => 'iu_tm_dog', 'RowID' => $data['iu_tm_dogid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }
	    return array('success' => TRUE, 'data' => $this->getRow($data['iu_tm_dogid'] ));
	} else {
	    return array('success' => FALSE, 'msg' => 'No data to store on server');
	}
    }
    function newRow($instanceid,$data)  {
	  $id = $this->jservice->get(array('Action' => 'NewGuid'));
	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'iu_tm_dog', 'RowID' => $id, 'DocumentID' => $instanceid, 'Values'=>$data)) == 'OK') {
	    return array('success' => TRUE, 'data' => $id);
	} else {
	    return array('success' => FALSE, 'msg' => 'Error while create new id');
	}
    }
    function getRows($sort=array())
		{
	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(iu_tm_dogid) as iu_tm_dogid, B2G(iu_tm_dogid) as id,B2G(instanceid) as instanceid, iu_tm_dog_BRIEF_F(iu_tm_dogid , NULL) as  brief,  DATE_FORMAT(thedate,\'%Y-%m-%d\') as  thedate,thenumber,dogfile,dogfile_ext,info', 'ViewName' => 'iu_tm_dog'));
	    if (count($res)) {
	        return $res;
	    } else {
	        return null;
	    }
		}
    function getRowsByInstance($id,$sort=array())
		{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(iu_tm_dogid) as iu_tm_dogid, B2G(iu_tm_dogid) as id,B2G(instanceid) as instanceid, iu_tm_dog_BRIEF_F(iu_tm_dogid , NULL) as  brief,  DATE_FORMAT(thedate,\'%Y-%m-%d\') as  thedate,thenumber,dogfile,dogfile_ext,info', 'ViewName' => 'iu_tm_dog', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
		}
    function getRowsByParent($id,$sort=array())
	{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(iu_tm_dogid) as iu_tm_dogid, B2G(iu_tm_dogid) as id,B2G(instanceid) as instanceid, iu_tm_dog_BRIEF_F(iu_tm_dogid , NULL) as  brief,  DATE_FORMAT(thedate,\'%Y-%m-%d\') as  thedate,thenumber,dogfile,dogfile_ext,info', 'ViewName' => 'iu_tm_dog', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
  }
    function deleteRow($id = null) {
	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => 'iu_tm_dog', 'RowID' => $id)) == 'OK')
	    $result = array('success' => TRUE);
	else
	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');
	return $result;
    }
}
?>