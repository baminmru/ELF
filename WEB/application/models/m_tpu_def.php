﻿
<?php
class  M_tpu_def extends CI_Model {
    function getRow($empId) {
    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');
	if (!empty($empId)){
	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'B2G(tpu_defid) as tpu_defid, B2G(tpu_defid) as id,B2G(instanceid) as instanceid, TPU_DEF_BRIEF_F(tpu_defid , NULL) as  brief,issystem, case issystem  when -1 then \'Да\' when 0 then \'Нет\'End  as issystem_grid,B2G(TheGroup) thegroup, Groups_BRIEF_F(thegroup, NULL) as thegroup_grid,B2G(TheUser) theuser, Users_BRIEF_F(theuser, NULL) as theuser_grid', 'PartName' => 'tpu_def', 'ID' =>  $empId 	));
	    if (!empty($res)) {
	        $result = $res[0];
	    }
	}
	return $result;
    }
    function setRow($data)  {
	    $data = (array)$data;
	if (!empty($data)) {
	    if (empty($data['tpu_defid'])) {
	        $data['tpu_defid'] = $this->jservice->get(array('Action' => 'NewGuid'));
	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpu_def', 'RowID' => $data['tpu_defid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }else{
	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => 'tpu_def', 'RowID' => $data['tpu_defid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }
	    return array('success' => TRUE, 'data' => $this->getRow($data['tpu_defid'] ));
	} else {
	    return array('success' => FALSE, 'msg' => 'No data to store on server');
	}
    }
    function newRow($instanceid,$data)  {
	  $id = $this->jservice->get(array('Action' => 'NewGuid'));
	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpu_def', 'RowID' => $id, 'DocumentID' => $instanceid, 'Values'=>$data)) == 'OK') {
	    return array('success' => TRUE, 'data' => $id);
	} else {
	    return array('success' => FALSE, 'msg' => 'Error while create new id');
	}
    }
    function getRows($sort=array())
		{
	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpu_defid) as tpu_defid, B2G(tpu_defid) as id,B2G(instanceid) as instanceid, TPU_DEF_BRIEF_F(tpu_defid , NULL) as  brief,issystem, case issystem  when -1 then \'Да\' when 0 then \'Нет\'End  as issystem_grid,B2G(TheGroup) thegroup, Groups_BRIEF_F(thegroup, NULL) as thegroup_grid,B2G(TheUser) theuser, Users_BRIEF_F(theuser, NULL) as theuser_grid', 'ViewName' => 'tpu_def'));
	    if (count($res)) {
	        return $res;
	    } else {
	        return null;
	    }
		}
    function getRowsByInstance($id,$sort=array())
		{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpu_defid) as tpu_defid, B2G(tpu_defid) as id,B2G(instanceid) as instanceid, TPU_DEF_BRIEF_F(tpu_defid , NULL) as  brief,issystem, case issystem  when -1 then \'Да\' when 0 then \'Нет\'End  as issystem_grid,B2G(TheGroup) thegroup, Groups_BRIEF_F(thegroup, NULL) as thegroup_grid,B2G(TheUser) theuser, Users_BRIEF_F(theuser, NULL) as theuser_grid', 'ViewName' => 'tpu_def', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
		}
    function getRowsByParent($id,$sort=array())
	{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpu_defid) as tpu_defid, B2G(tpu_defid) as id,B2G(instanceid) as instanceid, TPU_DEF_BRIEF_F(tpu_defid , NULL) as  brief,issystem, case issystem  when -1 then \'Да\' when 0 then \'Нет\'End  as issystem_grid,B2G(TheGroup) thegroup, Groups_BRIEF_F(thegroup, NULL) as thegroup_grid,B2G(TheUser) theuser, Users_BRIEF_F(theuser, NULL) as theuser_grid', 'ViewName' => 'tpu_def', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
  }
    function deleteRow($id = null) {
	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => 'tpu_def', 'RowID' => $id)) == 'OK')
	    $result = array('success' => TRUE);
	else
	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');
	return $result;
    }
}
?>