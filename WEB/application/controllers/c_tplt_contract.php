<?php
	 class C_tplt_contract extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLT_CONTRACT.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLT_CONTRACT.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tplt_contractid' =>  $this->input->get_post('tplt_contractid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'fld12' =>   $this->input->get_post('fld12', TRUE)
                ,'fld13' =>   $this->input->get_post('fld13', TRUE)
                ,'fld14' =>   $this->input->get_post('fld14', TRUE)
                ,'fld15' =>   $this->input->get_post('fld15', TRUE)
                ,'fld16' =>   $this->input->get_post('fld16', TRUE)
                ,'fld17' =>   $this->input->get_post('fld17', TRUE)
                ,'fld18' =>   $this->input->get_post('fld18', TRUE)
                ,'fld19' =>   $this->input->get_post('fld19', TRUE)
                ,'fld20' =>   $this->input->get_post('fld20', TRUE)
                ,'fld21' =>   $this->input->get_post('fld21', TRUE)
                ,'fld22' =>   $this->input->get_post('fld22', TRUE)
                ,'fld23' =>   $this->input->get_post('fld23', TRUE)
                ,'fld24' =>   $this->input->get_post('fld24', TRUE)
                ,'fld25' =>   $this->input->get_post('fld25', TRUE)
                ,'fld26' =>   $this->input->get_post('fld26', TRUE)
                ,'fld27' =>   $this->input->get_post('fld27', TRUE)
                ,'fld28' =>   $this->input->get_post('fld28', TRUE)
                ,'fld29' =>   $this->input->get_post('fld29', TRUE)
                ,'fld30' =>   $this->input->get_post('fld30', TRUE)
                ,'fld31' =>   $this->input->get_post('fld31', TRUE)
                ,'fld32' =>   $this->input->get_post('fld32', TRUE)
                ,'fld33' =>   $this->input->get_post('fld33', TRUE)
                ,'fld34' =>   $this->input->get_post('fld34', TRUE)
                ,'fld35' =>   $this->input->get_post('fld35', TRUE)
                ,'fld36' =>   $this->input->get_post('fld36', TRUE)
                ,'fld37' =>   $this->input->get_post('fld37', TRUE)
                ,'fld40' =>   $this->input->get_post('fld40', TRUE)
                ,'fld41' =>   $this->input->get_post('fld41', TRUE)
                ,'fld42' =>   $this->input->get_post('fld42', TRUE)
                ,'fld43' =>   $this->input->get_post('fld43', TRUE)
                ,'fld45' =>   $this->input->get_post('fld45', TRUE)
                ,'fld46' =>   $this->input->get_post('fld46', TRUE)
                ,'fld47' =>   $this->input->get_post('fld47', TRUE)
                ,'fld48' =>   $this->input->get_post('fld48', TRUE)
                ,'fld49' =>   $this->input->get_post('fld49', TRUE)
                ,'fld50' =>   $this->input->get_post('fld50', TRUE)
                ,'fld51' =>   $this->input->get_post('fld51', TRUE)
                ,'fld52' =>   $this->input->get_post('fld52', TRUE)
                ,'fld53' =>   $this->input->get_post('fld53', TRUE)
                ,'fld54' =>   $this->input->get_post('fld54', TRUE)
                ,'fld55' =>   $this->input->get_post('fld55', TRUE)
                ,'fld56' =>   $this->input->get_post('fld56', TRUE)
                ,'fld57' =>   $this->input->get_post('fld57', TRUE)
                ,'fld58' =>   $this->input->get_post('fld58', TRUE)
                ,'fld59' =>   $this->input->get_post('fld59', TRUE)
                ,'fld60' =>   $this->input->get_post('fld60', TRUE)
                ,'fld61' =>   $this->input->get_post('fld61', TRUE)
                ,'fld62' =>   $this->input->get_post('fld62', TRUE)
                ,'fld63' =>   $this->input->get_post('fld63', TRUE)
                ,'fld64' =>   $this->input->get_post('fld64', TRUE)
                ,'fld65' =>   $this->input->get_post('fld65', TRUE)
                ,'fld66' =>   $this->input->get_post('fld66', TRUE)
                ,'fld67' =>   $this->input->get_post('fld67', TRUE)
                ,'fld68' =>   $this->input->get_post('fld68', TRUE)
                ,'fld69' =>   $this->input->get_post('fld69', TRUE)
                ,'fld70' =>   $this->input->get_post('fld70', TRUE)
                ,'fld71' =>   $this->input->get_post('fld71', TRUE)
                ,'fld72' =>   $this->input->get_post('fld72', TRUE)
                ,'fld73' =>   $this->input->get_post('fld73', TRUE)
                ,'fld81' =>   $this->input->get_post('fld81', TRUE)
                ,'fld82' =>   $this->input->get_post('fld82', TRUE)
                ,'fld83' =>   $this->input->get_post('fld83', TRUE)
                ,'fld84' =>   $this->input->get_post('fld84', TRUE)
                ,'fld85' =>   $this->input->get_post('fld85', TRUE)
                ,'fld86' =>   $this->input->get_post('fld86', TRUE)
                ,'fld87' =>   $this->input->get_post('fld87', TRUE)
                ,'fld88' =>   $this->input->get_post('fld88', TRUE)
                ,'fld89' =>   $this->input->get_post('fld89', TRUE)
                ,'fld90' =>   $this->input->get_post('fld90', TRUE)
                ,'fld92' =>   $this->input->get_post('fld92', TRUE)
                ,'fld93' =>   $this->input->get_post('fld93', TRUE)
                ,'fld94' =>   $this->input->get_post('fld94', TRUE)
                ,'fld95' =>   $this->input->get_post('fld95', TRUE)
                ,'fld96' =>   $this->input->get_post('fld96', TRUE)
                ,'fld97' =>   $this->input->get_post('fld97', TRUE)
                ,'fld98' =>   $this->input->get_post('fld98', TRUE)
                ,'fld99' =>   $this->input->get_post('fld99', TRUE)
                ,'fld100' =>   $this->input->get_post('fld100', TRUE)
                ,'fld101' =>   $this->input->get_post('fld101', TRUE)
                ,'fld102' =>   $this->input->get_post('fld102', TRUE)
                ,'fld103' =>   $this->input->get_post('fld103', TRUE)
                ,'fld104' =>   $this->input->get_post('fld104', TRUE)
            );
            $tplt_contract = $this->m_tplt_contract->setRow($data);
            print json_encode($tplt_contract);
    }
    function newRow() {
            log_message('debug', 'TPLT_CONTRACT.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tplt_contractid' =>  $this->input->get_post('tplt_contractid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'fld12' =>   $this->input->get_post('fld12', TRUE)
                ,'fld13' =>   $this->input->get_post('fld13', TRUE)
                ,'fld14' =>   $this->input->get_post('fld14', TRUE)
                ,'fld15' =>   $this->input->get_post('fld15', TRUE)
                ,'fld16' =>   $this->input->get_post('fld16', TRUE)
                ,'fld17' =>   $this->input->get_post('fld17', TRUE)
                ,'fld18' =>   $this->input->get_post('fld18', TRUE)
                ,'fld19' =>   $this->input->get_post('fld19', TRUE)
                ,'fld20' =>   $this->input->get_post('fld20', TRUE)
                ,'fld21' =>   $this->input->get_post('fld21', TRUE)
                ,'fld22' =>   $this->input->get_post('fld22', TRUE)
                ,'fld23' =>   $this->input->get_post('fld23', TRUE)
                ,'fld24' =>   $this->input->get_post('fld24', TRUE)
                ,'fld25' =>   $this->input->get_post('fld25', TRUE)
                ,'fld26' =>   $this->input->get_post('fld26', TRUE)
                ,'fld27' =>   $this->input->get_post('fld27', TRUE)
                ,'fld28' =>   $this->input->get_post('fld28', TRUE)
                ,'fld29' =>   $this->input->get_post('fld29', TRUE)
                ,'fld30' =>   $this->input->get_post('fld30', TRUE)
                ,'fld31' =>   $this->input->get_post('fld31', TRUE)
                ,'fld32' =>   $this->input->get_post('fld32', TRUE)
                ,'fld33' =>   $this->input->get_post('fld33', TRUE)
                ,'fld34' =>   $this->input->get_post('fld34', TRUE)
                ,'fld35' =>   $this->input->get_post('fld35', TRUE)
                ,'fld36' =>   $this->input->get_post('fld36', TRUE)
                ,'fld37' =>   $this->input->get_post('fld37', TRUE)
                ,'fld40' =>   $this->input->get_post('fld40', TRUE)
                ,'fld41' =>   $this->input->get_post('fld41', TRUE)
                ,'fld42' =>   $this->input->get_post('fld42', TRUE)
                ,'fld43' =>   $this->input->get_post('fld43', TRUE)
                ,'fld45' =>   $this->input->get_post('fld45', TRUE)
                ,'fld46' =>   $this->input->get_post('fld46', TRUE)
                ,'fld47' =>   $this->input->get_post('fld47', TRUE)
                ,'fld48' =>   $this->input->get_post('fld48', TRUE)
                ,'fld49' =>   $this->input->get_post('fld49', TRUE)
                ,'fld50' =>   $this->input->get_post('fld50', TRUE)
                ,'fld51' =>   $this->input->get_post('fld51', TRUE)
                ,'fld52' =>   $this->input->get_post('fld52', TRUE)
                ,'fld53' =>   $this->input->get_post('fld53', TRUE)
                ,'fld54' =>   $this->input->get_post('fld54', TRUE)
                ,'fld55' =>   $this->input->get_post('fld55', TRUE)
                ,'fld56' =>   $this->input->get_post('fld56', TRUE)
                ,'fld57' =>   $this->input->get_post('fld57', TRUE)
                ,'fld58' =>   $this->input->get_post('fld58', TRUE)
                ,'fld59' =>   $this->input->get_post('fld59', TRUE)
                ,'fld60' =>   $this->input->get_post('fld60', TRUE)
                ,'fld61' =>   $this->input->get_post('fld61', TRUE)
                ,'fld62' =>   $this->input->get_post('fld62', TRUE)
                ,'fld63' =>   $this->input->get_post('fld63', TRUE)
                ,'fld64' =>   $this->input->get_post('fld64', TRUE)
                ,'fld65' =>   $this->input->get_post('fld65', TRUE)
                ,'fld66' =>   $this->input->get_post('fld66', TRUE)
                ,'fld67' =>   $this->input->get_post('fld67', TRUE)
                ,'fld68' =>   $this->input->get_post('fld68', TRUE)
                ,'fld69' =>   $this->input->get_post('fld69', TRUE)
                ,'fld70' =>   $this->input->get_post('fld70', TRUE)
                ,'fld71' =>   $this->input->get_post('fld71', TRUE)
                ,'fld72' =>   $this->input->get_post('fld72', TRUE)
                ,'fld73' =>   $this->input->get_post('fld73', TRUE)
                ,'fld81' =>   $this->input->get_post('fld81', TRUE)
                ,'fld82' =>   $this->input->get_post('fld82', TRUE)
                ,'fld83' =>   $this->input->get_post('fld83', TRUE)
                ,'fld84' =>   $this->input->get_post('fld84', TRUE)
                ,'fld85' =>   $this->input->get_post('fld85', TRUE)
                ,'fld86' =>   $this->input->get_post('fld86', TRUE)
                ,'fld87' =>   $this->input->get_post('fld87', TRUE)
                ,'fld88' =>   $this->input->get_post('fld88', TRUE)
                ,'fld89' =>   $this->input->get_post('fld89', TRUE)
                ,'fld90' =>   $this->input->get_post('fld90', TRUE)
                ,'fld92' =>   $this->input->get_post('fld92', TRUE)
                ,'fld93' =>   $this->input->get_post('fld93', TRUE)
                ,'fld94' =>   $this->input->get_post('fld94', TRUE)
                ,'fld95' =>   $this->input->get_post('fld95', TRUE)
                ,'fld96' =>   $this->input->get_post('fld96', TRUE)
                ,'fld97' =>   $this->input->get_post('fld97', TRUE)
                ,'fld98' =>   $this->input->get_post('fld98', TRUE)
                ,'fld99' =>   $this->input->get_post('fld99', TRUE)
                ,'fld100' =>   $this->input->get_post('fld100', TRUE)
                ,'fld101' =>   $this->input->get_post('fld101', TRUE)
                ,'fld102' =>   $this->input->get_post('fld102', TRUE)
                ,'fld103' =>   $this->input->get_post('fld103', TRUE)
                ,'fld104' =>   $this->input->get_post('fld104', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tplt_contract= $this->m_tplt_contract->newRow($instanceid,$data);
            $return = $tplt_contract;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLT_CONTRACT.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tplt_contract = $this->m_tplt_contract->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tplt_contract
            );
            print json_encode($return);
        }
    }
    function getRows() {
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'fld12', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tplt_contract= $this->m_tplt_contract->getRowsByInstance($instanceid,$sort);
                }else{
                    $tplt_contract= $this->m_tplt_contract->getRows($sort);
                }
            }else{
              $tplt_contract= $this->m_tplt_contract->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplt_contract
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLT_CONTRACT.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'fld12', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tplt_contract= $this->m_tplt_contract->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplt_contract
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need instanceid to query.'
            );
        }
        print json_encode($return);
    }
    function getRowsByParent() {
        log_message('debug', 'TPLT_CONTRACT.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'fld12', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tplt_contract= $this->m_tplt_contract->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tplt_contract
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need parent parentid to query.'
            );
        }
        print json_encode($return);
    }
    function deleteRow() {
        log_message('debug', 'TPLT_CONTRACT.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tplt_contractid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tplt_contract->deleteRow($tempId);
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'No  ID to delete'
            );
        }
        print json_encode($return);
    }
    private function _loadModels () {
        $this->load->model('M_tplt_contract', 'm_tplt_contract');
    }
}
?>