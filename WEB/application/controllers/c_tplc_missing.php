<?php
	 class C_tplc_missing extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLC_MISSING.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLC_MISSING.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tplc_missingid' =>  $this->input->get_post('tplc_missingid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'atype' =>   $this->input->get_post('atype', TRUE)
                ,'adate' =>   $this->input->get_post('adate', TRUE)
                ,'querycount' =>   $this->input->get_post('querycount', TRUE)
            );
            $tplc_missing = $this->m_tplc_missing->setRow($data);
            print json_encode($tplc_missing);
    }
    function newRow() {
            log_message('debug', 'TPLC_MISSING.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tplc_missingid' =>  $this->input->get_post('tplc_missingid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'atype' =>   $this->input->get_post('atype', TRUE)
                ,'adate' =>   $this->input->get_post('adate', TRUE)
                ,'querycount' =>   $this->input->get_post('querycount', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tplc_missing= $this->m_tplc_missing->newRow($instanceid,$data);
            $return = $tplc_missing;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLC_MISSING.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tplc_missing = $this->m_tplc_missing->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tplc_missing
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
            	$sort[] = array('property'=>'atype', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tplc_missing= $this->m_tplc_missing->getRowsByInstance($instanceid,$sort);
                }else{
                    $tplc_missing= $this->m_tplc_missing->getRows($sort);
                }
            }else{
              $tplc_missing= $this->m_tplc_missing->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplc_missing
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLC_MISSING.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'atype', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tplc_missing= $this->m_tplc_missing->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplc_missing
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
        log_message('debug', 'TPLC_MISSING.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'atype', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tplc_missing= $this->m_tplc_missing->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tplc_missing
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
        log_message('debug', 'TPLC_MISSING.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tplc_missingid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tplc_missing->deleteRow($tempId);
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
        $this->load->model('M_tplc_missing', 'm_tplc_missing');
    }
}
?>