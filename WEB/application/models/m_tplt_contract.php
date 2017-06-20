
<?php
class  M_tplt_contract extends CI_Model {
    function getRow($empId) {
    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');
	if (!empty($empId)){
	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'B2G(tplt_contractid) as tplt_contractid, B2G(tplt_contractid) as id,B2G(instanceid) as instanceid, TPLT_CONTRACT_BRIEF_F(tplt_contractid , NULL) as  brief,fld37,fld103,fld97,fld40,fld51,fld73,fld96,fld54,fld92,fld62,fld42,fld16,fld65,fld63,fld15,fld30,fld59,fld12,fld35,fld27,fld29,fld64,fld56,fld26,fld43,fld55,fld100,fld102,fld87,fld82,fld57,fld60,fld53,fld22,fld101,fld41,fld81,fld14,fld19,fld66,fld89,fld95,fld61,fld46,fld99,fld21,fld45,fld94,fld28,fld104,fld18,fld47,fld68,fld49,fld33,fld23,fld69,fld83,fld67,fld17,fld36,fld84,fld34,fld85,fld48,fld88,fld98,fld93,fld13,fld72,fld58,fld32,fld25,fld90,fld20,fld24,fld50,fld70,fld86,fld71,fld31,fld52', 'PartName' => 'tplt_contract', 'ID' =>  $empId 	));
	    if (!empty($res)) {
	        $result = $res[0];
	    }
	}
	return $result;
    }
    function setRow($data)  {
	    $data = (array)$data;
	if (!empty($data)) {
	    if (empty($data['tplt_contractid'])) {
	        $data['tplt_contractid'] = $this->jservice->get(array('Action' => 'NewGuid'));
	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tplt_contract', 'RowID' => $data['tplt_contractid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }else{
	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => 'tplt_contract', 'RowID' => $data['tplt_contractid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }
	    return array('success' => TRUE, 'data' => $this->getRow($data['tplt_contractid'] ));
	} else {
	    return array('success' => FALSE, 'msg' => 'No data to store on server');
	}
    }
    function newRow($instanceid,$data)  {
	  $id = $this->jservice->get(array('Action' => 'NewGuid'));
	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tplt_contract', 'RowID' => $id, 'DocumentID' => $instanceid, 'Values'=>$data)) == 'OK') {
	    return array('success' => TRUE, 'data' => $id);
	} else {
	    return array('success' => FALSE, 'msg' => 'Error while create new id');
	}
    }
    function getRows($sort=array())
		{
	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplt_contractid) as tplt_contractid, B2G(tplt_contractid) as id,B2G(instanceid) as instanceid, TPLT_CONTRACT_BRIEF_F(tplt_contractid , NULL) as  brief,fld37,fld103,fld97,fld40,fld51,fld73,fld96,fld54,fld92,fld62,fld42,fld16,fld65,fld63,fld15,fld30,fld59,fld12,fld35,fld27,fld29,fld64,fld56,fld26,fld43,fld55,fld100,fld102,fld87,fld82,fld57,fld60,fld53,fld22,fld101,fld41,fld81,fld14,fld19,fld66,fld89,fld95,fld61,fld46,fld99,fld21,fld45,fld94,fld28,fld104,fld18,fld47,fld68,fld49,fld33,fld23,fld69,fld83,fld67,fld17,fld36,fld84,fld34,fld85,fld48,fld88,fld98,fld93,fld13,fld72,fld58,fld32,fld25,fld90,fld20,fld24,fld50,fld70,fld86,fld71,fld31,fld52', 'ViewName' => 'tplt_contract'));
	    if (count($res)) {
	        return $res;
	    } else {
	        return null;
	    }
		}
    function getRowsByInstance($id,$sort=array())
		{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplt_contractid) as tplt_contractid, B2G(tplt_contractid) as id,B2G(instanceid) as instanceid, TPLT_CONTRACT_BRIEF_F(tplt_contractid , NULL) as  brief,fld37,fld103,fld97,fld40,fld51,fld73,fld96,fld54,fld92,fld62,fld42,fld16,fld65,fld63,fld15,fld30,fld59,fld12,fld35,fld27,fld29,fld64,fld56,fld26,fld43,fld55,fld100,fld102,fld87,fld82,fld57,fld60,fld53,fld22,fld101,fld41,fld81,fld14,fld19,fld66,fld89,fld95,fld61,fld46,fld99,fld21,fld45,fld94,fld28,fld104,fld18,fld47,fld68,fld49,fld33,fld23,fld69,fld83,fld67,fld17,fld36,fld84,fld34,fld85,fld48,fld88,fld98,fld93,fld13,fld72,fld58,fld32,fld25,fld90,fld20,fld24,fld50,fld70,fld86,fld71,fld31,fld52', 'ViewName' => 'tplt_contract', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
		}
    function getRowsByParent($id,$sort=array())
	{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplt_contractid) as tplt_contractid, B2G(tplt_contractid) as id,B2G(instanceid) as instanceid, TPLT_CONTRACT_BRIEF_F(tplt_contractid , NULL) as  brief,fld37,fld103,fld97,fld40,fld51,fld73,fld96,fld54,fld92,fld62,fld42,fld16,fld65,fld63,fld15,fld30,fld59,fld12,fld35,fld27,fld29,fld64,fld56,fld26,fld43,fld55,fld100,fld102,fld87,fld82,fld57,fld60,fld53,fld22,fld101,fld41,fld81,fld14,fld19,fld66,fld89,fld95,fld61,fld46,fld99,fld21,fld45,fld94,fld28,fld104,fld18,fld47,fld68,fld49,fld33,fld23,fld69,fld83,fld67,fld17,fld36,fld84,fld34,fld85,fld48,fld88,fld98,fld93,fld13,fld72,fld58,fld32,fld25,fld90,fld20,fld24,fld50,fld70,fld86,fld71,fld31,fld52', 'ViewName' => 'tplt_contract', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
  }
    function deleteRow($id = null) {
	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => 'tplt_contract', 'RowID' => $id)) == 'OK')
	    $result = array('success' => TRUE);
	else
	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');
	return $result;
    }
}
?>