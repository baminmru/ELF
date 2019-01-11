
<?php
class  M_tplc_header extends CI_Model {
    function getRow($empId) {
    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');
	if (!empty($empId)){
	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'B2G(tplc_headerid) as tplc_headerid, B2G(tplc_headerid) as id,B2G(instanceid) as instanceid, TPLC_HEADER_BRIEF_F(tplc_headerid , NULL) as  brief,B2G(ID_BD) id_bd, TPLT_BDEVICES_BRIEF_F(id_bd, NULL) as id_bd_grid', 'PartName' => 'tplc_header', 'ID' =>  $empId 	));
	    if (!empty($res)) {
	        $result = $res[0];
	    }
	}
	return $result;
    }
    function setRow($data)  {
	    $data = (array)$data;
	if (!empty($data)) {
	    if (empty($data['tplc_headerid'])) {
	        $data['tplc_headerid'] = $this->jservice->get(array('Action' => 'NewGuid'));
	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tplc_header', 'RowID' => $data['tplc_headerid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }else{
	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => 'tplc_header', 'RowID' => $data['tplc_headerid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }
	    return array('success' => TRUE, 'data' => $this->getRow($data['tplc_headerid'] ));
	} else {
	    return array('success' => FALSE, 'msg' => 'No data to store on server');
	}
    }
    function newRow($instanceid,$data)  {
	  $id = $this->jservice->get(array('Action' => 'NewGuid'));
	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tplc_header', 'RowID' => $id, 'DocumentID' => $instanceid, 'Values'=>$data)) == 'OK') {
	    return array('success' => TRUE, 'data' => $id);
	} else {
	    return array('success' => FALSE, 'msg' => 'Error while create new id');
	}
    }
    function getRows($sort=array())
		{
	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplc_headerid) as tplc_headerid, B2G(tplc_headerid) as id,B2G(instanceid) as instanceid, TPLC_HEADER_BRIEF_F(tplc_headerid , NULL) as  brief,B2G(ID_BD) id_bd, TPLT_BDEVICES_BRIEF_F(id_bd, NULL) as id_bd_grid', 'ViewName' => 'tplc_header'));
	    if (count($res)) {
	        return $res;
	    } else {
	        return null;
	    }
		}
    function getRowsByInstance($id,$sort=array())
		{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplc_headerid) as tplc_headerid, B2G(tplc_headerid) as id,B2G(instanceid) as instanceid, TPLC_HEADER_BRIEF_F(tplc_headerid , NULL) as  brief,B2G(ID_BD) id_bd, TPLT_BDEVICES_BRIEF_F(id_bd, NULL) as id_bd_grid', 'ViewName' => 'tplc_header', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
		}
    function getRowsByParent($id,$sort=array())
	{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplc_headerid) as tplc_headerid, B2G(tplc_headerid) as id,B2G(instanceid) as instanceid, TPLC_HEADER_BRIEF_F(tplc_headerid , NULL) as  brief,B2G(ID_BD) id_bd, TPLT_BDEVICES_BRIEF_F(id_bd, NULL) as id_bd_grid', 'ViewName' => 'tplc_header', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
  }
    function deleteRow($id = null) {
	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => 'tplc_header', 'RowID' => $id)) == 'OK')
	    $result = array('success' => TRUE);
	else
	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');
	return $result;
    }
}
?>