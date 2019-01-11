<?php
	 class C_tplc_header extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLC_HEADER.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLC_HEADER.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tplc_headerid' =>  $this->input->get_post('tplc_headerid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'id_bd' =>   $this->input->get_post('id_bd', TRUE)
            );
            $tplc_header = $this->m_tplc_header->setRow($data);
            print json_encode($tplc_header);
    }
    function newRow() {
            log_message('debug', 'TPLC_HEADER.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tplc_headerid' =>  $this->input->get_post('tplc_headerid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'id_bd' =>   $this->input->get_post('id_bd', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tplc_header= $this->m_tplc_header->newRow($instanceid,$data);
            $return = $tplc_header;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLC_HEADER.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tplc_header = $this->m_tplc_header->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tplc_header
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
            	$sort[] = array('property'=>'id_bd', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tplc_header= $this->m_tplc_header->getRowsByInstance($instanceid,$sort);
                }else{
                    $tplc_header= $this->m_tplc_header->getRows($sort);
                }
            }else{
              $tplc_header= $this->m_tplc_header->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplc_header
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLC_HEADER.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'id_bd', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tplc_header= $this->m_tplc_header->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplc_header
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
        log_message('debug', 'TPLC_HEADER.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'id_bd', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tplc_header= $this->m_tplc_header->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tplc_header
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
        log_message('debug', 'TPLC_HEADER.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tplc_headerid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tplc_header->deleteRow($tempId);
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
        $this->load->model('M_tplc_header', 'm_tplc_header');
    }
}
?>