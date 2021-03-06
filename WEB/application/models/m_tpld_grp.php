﻿
<?php
class  M_tpld_grp extends CI_Model {
    function getRow($empId) {
    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');
	if (!empty($empId)){
	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'B2G(tpld_grpid) as tpld_grpid, B2G(tpld_grpid) as id,B2G(instanceid) as instanceid, TPLD_GRP_BRIEF_F(tpld_grpid , NULL) as  brief,cgrpnm,B2G(theClient) theclient, bpc_info_BRIEF_F(theclient, NULL) as theclient_grid,ctxt', 'PartName' => 'tpld_grp', 'ID' =>  $empId 	));
	    if (!empty($res)) {
	        $result = $res[0];
	    }
	}
	return $result;
    }
    function setRow($data)  {
	    $data = (array)$data;
	if (!empty($data)) {
	    if (empty($data['tpld_grpid'])) {
	        $data['tpld_grpid'] = $this->jservice->get(array('Action' => 'NewGuid'));
	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpld_grp', 'RowID' => $data['tpld_grpid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }else{
	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => 'tpld_grp', 'RowID' => $data['tpld_grpid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }
	    return array('success' => TRUE, 'data' => $this->getRow($data['tpld_grpid'] ));
	} else {
	    return array('success' => FALSE, 'msg' => 'No data to store on server');
	}
    }
    function newRow($instanceid,$data)  {
	  $id = $this->jservice->get(array('Action' => 'NewGuid'));
	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpld_grp', 'RowID' => $id, 'DocumentID' => $instanceid, 'Values'=>$data)) == 'OK') {
	    return array('success' => TRUE, 'data' => $id);
	} else {
	    return array('success' => FALSE, 'msg' => 'Error while create new id');
	}
    }
    function getRows($sort=array())
		{
	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpld_grpid) as tpld_grpid, B2G(tpld_grpid) as id,B2G(instanceid) as instanceid, TPLD_GRP_BRIEF_F(tpld_grpid , NULL) as  brief,cgrpnm,B2G(theClient) theclient, bpc_info_BRIEF_F(theclient, NULL) as theclient_grid,ctxt', 'ViewName' => 'tpld_grp'));
	    if (count($res)) {
	        return $res;
	    } else {
	        return null;
	    }
		}
    function getRowsByInstance($id,$sort=array())
		{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpld_grpid) as tpld_grpid, B2G(tpld_grpid) as id,B2G(instanceid) as instanceid, TPLD_GRP_BRIEF_F(tpld_grpid , NULL) as  brief,cgrpnm,B2G(theClient) theclient, bpc_info_BRIEF_F(theclient, NULL) as theclient_grid,ctxt', 'ViewName' => 'tpld_grp', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
		}
    function getRowsByParent($id,$sort=array())
	{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpld_grpid) as tpld_grpid, B2G(tpld_grpid) as id,B2G(instanceid) as instanceid, TPLD_GRP_BRIEF_F(tpld_grpid , NULL) as  brief,cgrpnm,B2G(theClient) theclient, bpc_info_BRIEF_F(theclient, NULL) as theclient_grid,ctxt', 'ViewName' => 'tpld_grp', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
  }
    function deleteRow($id = null) {
	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => 'tpld_grp', 'RowID' => $id)) == 'OK')
	    $result = array('success' => TRUE);
	else
	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');
	return $result;
    }
}
?>